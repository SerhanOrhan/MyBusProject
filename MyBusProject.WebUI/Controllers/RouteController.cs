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
    public class RouteController : Controller
    {
        private IRouteService _routeService;
        private ITicketService _ticketService;
        public RouteController(IRouteService routeService,ITicketService ticketService)
        {
            _routeService = routeService;
            _ticketService = ticketService;
        }
        public IActionResult Details(int id)
        {
            Route route = _routeService.GetRouteDetails(id);
            int routeSeatNumber = _ticketService.GetCountBySeat(id);
            List<int> fullSeats = _ticketService.GetSeat(id);
            var seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            foreach (var item in fullSeats)
            {
                seats.Remove(item);
            }
            ViewBag.Number = routeSeatNumber;
            ViewBag.Seats = new SelectList(seats);
            if (route==null)
            {
                return NotFound();
            }
            else
            {
                var cityModel = new TicketRoute()
                {
                    NewRoute=route
                };
                return View(route);
            }
        }
        [HttpPost]
        public IActionResult Details(int routeId, double price,string startRoute,string endRoute,int seatNo,string email,string name,string surname)
        {
            var entity = new Ticket()
            {
                Name = name,
                Surname = surname,
                Mail = email,
                StartCity = startRoute,
                EndCity = endRoute,
                SeatNo = seatNo,
                Price = price,
                RouteId = routeId
            };
            _ticketService.Create(entity);
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            Ticket newTicket= _ticketService.GetLastRecord();
            int routeId = _ticketService.GetId();
            string routeHour = _ticketService.GetHour(routeId);
            string routeDate = _ticketService.GetDate(routeId);

            var TicketRoute = new TicketRoute()
            {
                Date=routeDate,
                Hour=routeHour,
                Ticket=newTicket
            };
            return View(TicketRoute);
        }
    }
    
}
