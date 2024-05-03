using AutoMapper;
using Business.Abstracts;
using Core.crossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;


namespace Business.Feature.Products.Commands.Create
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ICategoryService _categoryService;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _categoryService = categoryService;
            } 

            public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                if (request.Price < 0)
                    throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");

                Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == request.Name);
                if (productWithSameName is not null)
                    throw new BusinessException("Aynı isimde 2. ürün eklenemez.");


                Category? category = await _categoryService.GetByIdAsync(request.CategoryId);
                if (category is null)
                    throw new BusinessException("Kategori bulunamadı");

                Product product = _mapper.Map<Product>(request);

                await _productRepository.AddAsync(product);
            }
        }



    }
}
