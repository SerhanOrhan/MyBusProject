using MyBusProject.Business.Abstract;
using MyBusProject.Data.Abstract;
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
        private ITicketRepository _ticketRepository;
        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Create(Ticket entity)
        {
            _ticketRepository.Create(entity);
        }

        public void Delete(Ticket entity)
        {
            _ticketRepository.Delete(entity);
        }

        public List<Ticket> GetAll()
        {
           return _ticketRepository.GetAll();
        }

        public Ticket GetById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public int GetCountBySeat(int routeId)
        {
            return _ticketRepository.GetCountBySeat(routeId);
        }

        public string GetDate(int id)
        {
            return _ticketRepository.GetDate(id);
        }

        public string GetHour(int id)
        {
            return _ticketRepository.GetHour(id);
        }

        public int GetId()
        {
            return _ticketRepository.GetId();
        }

        public Ticket GetLastRecord()
        {
            return _ticketRepository.GetLastRecord();
        }

        public List<int> GetSeat(int routeId)
        {
            return _ticketRepository.GetSeat(routeId);
        }

        public void Update(Ticket entity)
        {
            _ticketRepository.Update(entity);
        }

        public void Update(Ticket entity, int[] ticketIds)
        {
            throw new NotImplementedException();
        }
    }
}
