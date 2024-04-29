using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrates
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            if (product.Price < 0)
                throw new Exception("ürün fiyatı 0dan küçük olamaz");

            _productRepository.Add(product);   
        }

        public void Delete(int id)
        {
            Console.Write("silme işlemi tamamnaldı");
        }

        public List<Product> GetAll()
        {
           return _productRepository.GetAll();
        }
    }
}
