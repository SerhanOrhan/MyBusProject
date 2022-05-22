using MyBusProject.Data.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Concrete.EfCore
{
    public class EfCoreTicketRepository : EfCoreGenericRepository<Ticket, MyBusProjectContext>, ITicketRepository
    {
        public int GetCountBySeat(int routeId)
        {
            using (var context = new MyBusProjectContext())
            {
               return context.Tickets
                    .Where(i => i.RouteId == routeId)
                    .Select(i => i.SeatNo)
                    .Count();
            }
        }

        public string GetDate(int id)
        {
            using (var context = new MyBusProjectContext())
            {
                var lastTicketDate = context.Routes
                    .Where(i => i.RouteId == id)
                    .Select(i => i.Date)
                    .FirstOrDefault();
                return lastTicketDate;
            }
        }

        public string GetHour(int id)
        {
            using (var context = new MyBusProjectContext())
            {
                var lastTicketHour = context.Routes
                    .Where(i => i.RouteId == id)
                    .Select(i => i.Hour)
                    .FirstOrDefault();
                return lastTicketHour;
            }
        }

        public int GetId()
        {
            using (var context = new MyBusProjectContext())
            {
                var id = context.Tickets
                    .OrderByDescending(i => i.TicketId)
                    .Select(i => i.RouteId)
                    .FirstOrDefault();
                return id;
            }
        }

        public Ticket GetLastRecord()
        {
            using (var context = new MyBusProjectContext())
            {
                var lastTicket = context.Tickets
                    .OrderByDescending(i => i.RouteId)
                    .FirstOrDefault();
                return lastTicket;
            }
        }

        public List<int> GetSeat(int routeId)
        {
            using (var context=new MyBusProjectContext())
            {
                var seat = context.Tickets
                    .Where(i => i.RouteId == routeId)
                    .Select(i => i.SeatNo)
                    .ToList();
                return seat;
            }
        }
    }
}
