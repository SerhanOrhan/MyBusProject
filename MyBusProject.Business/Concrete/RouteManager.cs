using MyBusProject.Business.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Concrete
{
    public class RouteManager : IRouteService
    {
        private IRouteService _routeService;
        public RouteManager(IRouteService routeService)
        {
            _routeService = routeService;
        }
        public void Create(Route entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Route entity)
        {
            throw new NotImplementedException();
        }

        public List<Route> GetAll()
        {
            throw new NotImplementedException();
        }

        public Route GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Route entity)
        {
            throw new NotImplementedException();
        }
    }
}
