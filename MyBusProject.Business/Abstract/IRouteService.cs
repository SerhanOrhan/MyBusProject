using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Abstract
{
   public interface IRouteService
    {
        Route GetById(int id);
        List<Route> GetAll();
        void Create(Route entity);
        void Delete(Route entity);
        void Update(Route entity);
    }
}
