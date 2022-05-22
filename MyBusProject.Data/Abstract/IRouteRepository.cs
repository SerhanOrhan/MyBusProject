using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Abstract
{
    public interface IRouteRepository : IRepository<Route>
    {
        string GetStartCity(string startCity);
        string GetEndCity(string endCity);
        string GetRouteDate(DateTime date);
        List<Route> GetTravel(string startCity, string endCity,DateTime date);
        int GetRoteByStartEnd(string start, string route1, string route2, string route3, string end);
        Route GetRouteDetails(int id);
    }
}
