﻿using MyBusProject.Business.Abstract;
using MyBusProject.Data.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Business.Concrete
{
    public class VoyageManager : IVoyageService
    {
        private IVoyageRepository _voyageService;
        public VoyageManager(IVoyageRepository voyageService)
        {
            _voyageService = voyageService;
        }
        public void Create(Voyage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Voyage entity)
        {
            throw new NotImplementedException();
        }

        public List<Voyage> GetAll()
        {
            throw new NotImplementedException();
        }

        public Voyage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Voyage entity)
        {
            throw new NotImplementedException();
        }
    }
}
