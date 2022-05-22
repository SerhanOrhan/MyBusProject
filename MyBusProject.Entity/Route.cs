using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
   public class Route
    {
        public int RouteId { get; set; }
        public string StartRoute { get; set; }
        public string Route1 { get; set; }
        public string Route2 { get; set; }
        public string Route3 { get; set; }
        public string EndRoute { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public double Price { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
