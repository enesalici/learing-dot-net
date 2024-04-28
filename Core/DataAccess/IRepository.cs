using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
    }
}
