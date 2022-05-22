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
    public class CityManager : ICityService
    {
        private ICityRepository _cityRepository;
        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public string cityName()
        {
            throw new NotImplementedException();
        }

        public void Create(City entity)
        {
            _cityRepository.Create(entity);
        }

        public void Delete(City entity)
        {
            _cityRepository.Delete(entity);
        }

        public List<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(City entity)
        {
            _cityRepository.Update(entity);
        }

        public void Update(City entity, int[] cityIds)
        {
            throw new NotImplementedException();
        }
    }
}
