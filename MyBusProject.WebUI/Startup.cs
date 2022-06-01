using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBusProject.Business.Abstract;
using MyBusProject.Business.Concrete;
using MyBusProject.Data.Abstract;
using MyBusProject.Data.Concrete;
using MyBusProject.Data.Concrete.EfCore;
using MyBusProject.WebUI.EmailServices;
using MyBusProject.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Idnetity  kutuphanesindeki tablelerin nereye nasýl ana  dbmize ekleneceðini belirttim
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=MyBusProjectDataDb"));
            //Mail iþlemleri ve maildeki güveliði saðlamak için tokenler kullanýlýr bu tokenlerde Role de kullanýcak rolelr berlýlendý
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 3; // 3 kere yanlýs gýrýlýrse
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//5 dk hesabý blockla

                //User
                options.User.RequireUniqueEmail = true;//email uniq olsun

                //SignIn
                options.SignIn.RequireConfirmedEmail = true;//Onaylanmamýs


            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true; // istek gönderirse sýfýrla süreyi demek
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);//20 dk istek yapmazsa 20dk sonra kullanýcýyý kullanýcý giriþi istiyor.
                options.Cookie = new CookieBuilder()
                {
                    HttpOnly = true,
                    Name = "MiniShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
            services.AddControllersWithViews();
            //Data Kýsmý Scop
            services.AddScoped<IRouteRepository, EfCoreRouteRepository>();
            services.AddScoped<ITicketRepository, EfCoreTicketRepository>();
            services.AddScoped<ICityRepository, EfCoreCityRepository>();

            //Business kýsmý scop
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IRouteService, RouteManager>();
            services.AddScoped<ITicketService, TicketManager>();
            services.AddScoped<IEmailSender, SmtpEmailSender>(i => new SmtpEmailSender(
                Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"),
                Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"]
                ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDataBase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
