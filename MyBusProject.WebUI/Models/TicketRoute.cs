using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI.Models
{
    public class TicketRoute
    {
        public Route NewRoute { get; set; }
        public string Hour { get; set; }
        public string Date { get; set; }
        public Ticket Ticket { get; set; }
        public List<City> Cities { get; set; }
        public List<Route> Routes { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
