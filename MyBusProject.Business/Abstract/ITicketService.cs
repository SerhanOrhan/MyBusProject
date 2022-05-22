using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
   public interface ITicketService
    {
        Ticket GetById(int id);
        List<Ticket> GetAll();
        void Create(Ticket entity);
        void Delete(Ticket entity);
        void Update(Ticket entity);
        void Update(Ticket entity, int[] ticketIds);
        int GetCountBySeat(int routeId);
        List<int> GetSeat(int routeId);
        Ticket GetLastRecord();
        int GetId();
        string GetDate(int id);
        string GetHour(int id);
    }
}
