using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext 
        where TEntity :  BaseEntity
    {
        
        private readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
           Context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
           return Context.Set<TEntity>().ToList();
        }
    }
}
