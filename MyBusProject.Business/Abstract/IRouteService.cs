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
        string GetStartCity(string startCity);
        string GetEndCity(string endCity);
        string GetRouteDate(DateTime date);
        List<Route> GetTravel(string startCity, string endCity,DateTime date);
        int GetRoteByStartEnd(string start, string route1, string route2, string route3, string end);
        Route GetRouteDetails(int id);
    }
}
