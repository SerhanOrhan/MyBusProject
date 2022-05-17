using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
    public class Station
    {
        public int VoyageId { get; set; }
        public Voyage Voyage { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
