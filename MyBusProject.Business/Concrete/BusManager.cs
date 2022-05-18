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
    public class BusManager : IBusService
    {
        private IBusRepository _busRepository;
        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public void Create(Bus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bus entity)
        {
            throw new NotImplementedException();
        }

        public List<Bus> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
