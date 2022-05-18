using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
   public interface IPassengerService
    {
        Passenger GetById(int id);
        List<Passenger> GetAll();
        void Create(Passenger entity);
        void Delete(Passenger entity);
        void Update(Passenger entity);
    }
}
