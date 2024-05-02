using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Product;
using Core.crossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concrates
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task Add(ProductToAddDto dto)
        {
            if (dto.Price < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");

            Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == dto.Name);
            if (productWithSameName is not null)
                throw new BusinessException("Aynı isimde 2. ürün eklenemez.");

            //Product product = new();
            //product.Name = dto.Name;
            //product.Price = dto.Price;
            //product.Stock = dto.Stock;
            //product.CategoryId = dto.CategoryId;

            Product product = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(product);
        }

        public void Delete(int id)
        {
            Product? productToDelete = _productRepository.Get(i => i.Id == id);

        }

        public async Task<List<ProductToListDto>> GetAll()
        {
            List<Product> products = await _productRepository.GetListAsync();
            List<ProductToListDto> response = _mapper.Map<List<ProductToListDto>>(products);
            return response;
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
