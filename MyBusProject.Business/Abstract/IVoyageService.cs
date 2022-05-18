using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
   public interface IVoyageService
    {
        Voyage GetById(int id);
        List<Voyage> GetAll();
        void Create(Voyage entity);
        void Delete(Voyage entity);
        void Update(Voyage entity);
    }
}
