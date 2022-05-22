using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyBusProject.Business.Abstract;
using MyBusProject.Entity;
using MyBusProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICityService _cityService;
        private IRouteService _routeService;
        public HomeController(ICityService cityService,IRouteService routeService)
        {
            _cityService = cityService;
            _routeService = routeService;
        }
        public IActionResult Index(string startroute,string endroute,DateTime date)
        {
            if (startroute==null || endroute==null || startroute==endroute)
            {
                var cityModel = new TicketRoute()
                {
                    Cities=_cityService.GetAll().OrderBy(i=>i.Name).ToList(),
                    Routes=null
                };
                ViewBag.Cities = new SelectList(cityModel.Cities, "CityId", "Name");
                return View(cityModel);
            }
            else
            {
                var cityModel = new TicketRoute()
                {
                    Cities = _cityService.GetAll(),
                    Routes=_routeService.GetTravel(startroute,endroute,date)
                };
                TempData["startRoute"] = _routeService.GetStartCity(startroute);
                TempData["endRoute"] = _routeService.GetEndCity(endroute);
                TempData["dateRoute"] = _routeService.GetRouteDate(date);
                ViewBag.Cities = new SelectList(cityModel.Cities, "CityId", "Name");
                return View(cityModel);
            }
        }
          public IActionResult Contact()
            {
                ViewData["title"] = "İletişim - ";
                return View();
            }

    }
}
