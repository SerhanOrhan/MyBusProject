using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
   public class Bus
    {
        public int BusId { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public bool IsActive { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Voyage> Voyages { get; set; }
    }
}
