using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : BaseEntity
    {
        public Product() { }

        public Product(int productId, string name, string description, int stock, int price, int categoryId)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}