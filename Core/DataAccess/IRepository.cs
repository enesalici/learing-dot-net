using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        void Add(T entity);
        void Delete(T entity);
    }
}
