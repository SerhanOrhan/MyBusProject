using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
   public class Ticket
    {
        public int TicketId { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passengers { get; set; }
    }
}
