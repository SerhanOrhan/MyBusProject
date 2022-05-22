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
            using (var context = new TContext())
            {
                context.Set<TEntitiy>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntitiy entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntitiy>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntitiy> GetAll()
        {
            using (var context= new TContext())
            {
               return context.Set<TEntitiy>().ToList();
            }
        }

        public TEntitiy GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntitiy>().Find(id);
            }
        }

        public void Update(TEntitiy entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
