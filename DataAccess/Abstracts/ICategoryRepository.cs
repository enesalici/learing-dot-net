using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        void Add(Category product);
        void Delete(int id);
    }
}
