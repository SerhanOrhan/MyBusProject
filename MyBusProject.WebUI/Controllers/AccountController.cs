using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBusProject.WebUI.EmailServices;
using MyBusProject.WebUI.Identity;
using MyBusProject.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");
                return View(model);
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Hesabınız onaylanmamış! Lütfen mail adresinize gelen onay linkine tıklayarak hesabınızı onaylayınız");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/"); // eğer returnUrl boşsa bunu yap demek. değilse returnUrldeki ifadeye git
            }
            CreateMessage("Şifreniz hatalı", "danger");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) //asenkron bir method bu şekilde oluşturulur
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)//Başarılı bir şekilde create gerçekleştiyse
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                //email gönderme işlemi
                await _emailSender.SendEmailAsync(model.Email, "Enuygun.com Confirm Account!", $"Lütfen email adresinizi onaylamak içi <a href='https://localhost:44306{url}'>tıklayınız!</a>");
                CreateMessage("Kayit işleminizi tamamlamak için mailinize gönderilen onaylama linkine tıklayınız!", "warning");
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Bir sorun oluştu", "warning");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (userId != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    CreateMessage("Hesabınız Onaylanmıştır", "success");
                }
                return View();
            }
            CreateMessage("Hesabınız onaylanamamıştır! Lütfen daha sonra tekrar deneyiniz.", "danger");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                CreateMessage("Lütfen email adresinizi giriniz", "warning");
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                CreateMessage("Böyle bir email adresi bulunamadı, lütfen kontrol ederek tekrar deneyınız", "danger");
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(
                email, "Enuygun.com Şifre Sıfırlama",
                $"Lütfen paralonızı yenilemek için  <a href='https://localhost:5001{url}'>Tıklayınız</a>"
                );
            CreateMessage("Şifre sıfırlama maili kayıtlı mail adresine gonderilmiştir lütfen kontrol ediniz.", "warning");
            return RedirectToAction("Login");
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Bir sorun oluştu daha sonra tekrar deneyiniz.", "danger");
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel()
            {
                Token = token
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                CreateMessage("Bir sorun oluştu lütfen bilgileri kontrol ederek tekrar deneyınız", "danger");
                return View();
            }
            var result = await _userManager.ResetPasswordAsync(
                user, model.Token, model.Password
                );
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            CreateMessage("Bir sorun oluştu lütfen admine başvurunuz.", "danger");
            return Redirect("~/");
        }
        private void CreateMessage(string message, string alertType)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alertType
            };
            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
