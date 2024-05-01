using Business.Abstracts;
using Core.crossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task Add(Product product)
        {

            if (product.Price < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");

            Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == product.Name);
            if (productWithSameName is not null)
                throw new BusinessException("Aynı isimde 2. ürün eklenemez.");

            await _productRepository.AddAsync(product);
        }

        public void Delete(int id)
        {
            Product? productToDelete = _productRepository.Get(i => i.Id == id);
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            // Cacheleme?
            return await _productRepository.GetListAsync();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
