using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{



    public class Product
    {
        public Product () { }

        public Product (int productId, string name, string description, int price) 
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        }
    
        public int ProductId { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
