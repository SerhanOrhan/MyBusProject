﻿using MyBusProject.Data.Abstract;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Concrete.EfCore
{
   public class EfCorePassengerRepository : EfCoreGenericRepository<Passenger,MyBusProjectContext>, IPassengerRepository
    {
    }
}