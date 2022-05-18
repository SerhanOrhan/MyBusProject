using MyBusProject.Business.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Concrete
{
    public class PassengerManager : IPassengerService
    {
        private IPassengerService _passengerService;
        public PassengerManager( IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        public void Create(Passenger entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Passenger entity)
        {
            throw new NotImplementedException();
        }

        public List<Passenger> GetAll()
        {
            throw new NotImplementedException();
        }

        public Passenger GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Passenger entity)
        {
            throw new NotImplementedException();
        }
    }
}
