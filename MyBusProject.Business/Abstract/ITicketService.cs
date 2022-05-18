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
    }
}
