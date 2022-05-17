using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
  public  class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string Cordinate { get; set; }
        public string Type { get; set; }
        public List<Station> Stations { get; set; }
    }
}
