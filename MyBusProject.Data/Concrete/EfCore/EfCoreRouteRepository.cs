using Microsoft.EntityFrameworkCore;
using MyBusProject.Data.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Concrete.EfCore
{
    public class EfCoreRouteRepository : EfCoreGenericRepository<Route, MyBusProjectContext>, IRouteRepository
    {
        public string GetEndCity(string endCity)
        {
            using (var context = new MyBusProjectContext())
            {
                var end = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(endCity))
                    .Select(i => i.Name)
                    .ToList();
                return end[0];
            }
        }

        public int GetRoteByStartEnd(string start, string route1, string route2, string route3, string end)
        {
            throw new NotImplementedException();
        }

        public Route GetRouteDetails(int id)
        {
            using (var context = new MyBusProjectContext())
            {
                return context.Routes
                    .Where(i => i.RouteId == id)
                    .AsNoTracking()
                    .FirstOrDefault();
            }
        }

        public string GetStartCity(string startCity)
        {
            using (var context = new MyBusProjectContext())
            {
                var start = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(startCity))
                    .Select(i => i.Name)
                    .ToList();
                return start[0];
            }
        }
        public string GetRouteDate(DateTime date)
        {
            using (var context = new MyBusProjectContext())
            {
                var routeDate = context.Routes
                    .Where(i => i.Date == Convert.ToString(date))
                    .Select(i => i.Date)
                    .FirstOrDefault();
                return routeDate;
            }
        }

        public List<Route> GetTravel(string startCity, string endCity,DateTime date)
        {
            using (var context = new MyBusProjectContext())
            {
                var dateyeni = date.ToString("yyyy-MM-dd");
                var start = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(startCity))
                    .Select(i => i.Name)
                    .ToList();
                var end = context.Cities
                   .Where(i => i.CityId == Convert.ToInt32(endCity))
                   .Select(i => i.Name)
                   .ToList();
                var routeDate = context.Routes
                    .Where(i => i.Date == Convert.ToString(dateyeni))
                    .Select(i => i.Date)
                    .ToList();
                    
                var routes = context.Routes
                     .FromSqlRaw($"select * from Routes where ((StartRoute='{start[0]}' or Route1='{start[0]}' or Route2='{start[0]}' or Route3='{start[0]}'  ) and (EndRoute='{end[0]}' or Route3='{end[0]}' or Route2='{end[0]}' or Route1='{end[0]}' )) and Date='{dateyeni}' ")
                     .ToList();
                return routes;
            } 
        }
    }
}
