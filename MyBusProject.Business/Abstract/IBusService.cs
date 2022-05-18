using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
   public interface IBusService
    {
        Bus GetById(int id);
        List<Bus> GetAll();
        void Create(Bus entity);
        void Delete(Bus entity);
        void Update(Bus entity);
    }
}
