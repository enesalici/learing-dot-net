using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
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

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);

            return data.ToList();
        }
    }
}
