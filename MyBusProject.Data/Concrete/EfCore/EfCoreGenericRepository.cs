using Microsoft.EntityFrameworkCore;
using MyBusProject.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntitiy, TContext> : IRepository<TEntitiy>
        where TEntitiy : class
        where TContext : DbContext, new()
    {
        public void Create(TEntitiy entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntitiy entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntitiy> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntitiy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntitiy entity)
        {
            throw new NotImplementedException();
        }
    }
}
