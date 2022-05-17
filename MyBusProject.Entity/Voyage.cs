using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
   public class Voyage
    {
        public int VoyageId { get; set; }
        public string StartRoute { get; set; }
        public string EndRoute { get; set; }
        public double Price { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public List<Station> Stations { get; set; }
    }
}
