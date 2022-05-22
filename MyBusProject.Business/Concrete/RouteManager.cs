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
    public class RouteManager : IRouteService
    {
        private IRouteRepository _routeRepository;
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public void Create(Route entity)
        {
            _routeRepository.Create(entity);
        }

        public void Delete(Route entity)
        {
            _routeRepository.Delete(entity);
        }

        public List<Route> GetAll()
        {
            return _routeRepository.GetAll();
        }

        public Route GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetEndCity(string endCity)
        {
            return _routeRepository.GetEndCity(endCity);
        }
        public string GetRouteDate(DateTime date)
        {
            return _routeRepository.GetRouteDate(date);
        }
        public int GetRoteByStartEnd(string start, string route1, string route2, string route3, string end)
        {
            return _routeRepository.GetRoteByStartEnd(start, route1, route2, route3, end);
        }

        public Route GetRouteDetails(int id)
        {
            return _routeRepository.GetRouteDetails(id);
        }

        public string GetStartCity(string startCity)
        {
            return _routeRepository.GetStartCity(startCity);
        }

        public List<Route> GetTravel(string startCity, string endCity,DateTime date)
        {
            return _routeRepository.GetTravel(startCity, endCity,date);
        }

        public void Update(Route entity)
        {
            _routeRepository.Update(entity);
        }
    }
}
