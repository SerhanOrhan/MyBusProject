using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
    public interface ICityService
    {
        City GetById(int id);
        List<City> GetAll();
        void Create(City entity);
        void Delete(City entity);
        void Update(City entity);
    }
}
