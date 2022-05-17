using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Entity
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BirthDay { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
