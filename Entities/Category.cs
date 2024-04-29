using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
        }

        public Category(int ıd, string name)
        {
            Id = ıd;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}