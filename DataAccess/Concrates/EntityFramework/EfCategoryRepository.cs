using Core.DataAccess;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrates.EntityFramework
{
    public class EfCategoryRepository : EfRepositoryBase<Category, BaseDbContext>, ICategoryRepository
    {
        public EfCategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
