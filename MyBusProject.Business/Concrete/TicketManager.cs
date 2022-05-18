using MyBusProject.Business.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Concrete
{
    public class TicketManager : ITicketService
    {
        private ITicketService _ticketService;
        public TicketManager(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public void Create(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
