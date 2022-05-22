using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Abstract
{
   public interface ITicketRepository : IRepository<Ticket>
    {
        int GetCountBySeat(int routeId);
        List<int> GetSeat(int routeId);
        Ticket GetLastRecord();
        int GetId();
        string GetDate(int id);
        string GetHour(int id);
    }
}
