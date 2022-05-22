using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBusProject.Business.Abstract;
using MyBusProject.Entity;
using MyBusProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ITicketService _ticketService;
        private ICityService _cityService;
        private IRouteService _routeService;

        public AdminController(ITicketService ticketService,ICityService cityService,IRouteService routeService)
        {
            _ticketService = ticketService;
            _cityService = cityService;
            _routeService = routeService;
        }
        public IActionResult AdminList()
        {
            return View(new TicketRoute()
            {
                Tickets = _ticketService.GetAll()
            });
        }
        public IActionResult CancelTicket(int ticketId)
        {
            var ticket = _ticketService.GetById(ticketId);
            if (ticket!=null)
            {
                _ticketService.Delete(ticket);
            }
            return RedirectToAction("AdminList");
        }
        public IActionResult CreateNewRoute()
        {
            ViewBag.Cities = new SelectList(_cityService.GetAll().OrderBy(i=>i.Name), "Name", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewRoute(Route route)
        {
            _routeService.Create(route);
            ViewBag.Cities = new SelectList(_cityService.GetAll().OrderBy(i => i.Name), "Name", "Name");
            return RedirectToAction("AdminList");
        }
    }
}
