using AutoMapper;
using Business.Abstracts;
using Business.Feature.Products.Dtos;
using Core.crossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ICategoryService _categoryService;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _categoryService = categoryService;
            }

            public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryService.GetByIdAsync(request.CategoryId);
                if (category == null)
                    throw new BusinessException("Böyle Bir Kategori bulunamaı");

                Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);

                if (product == null)
                    throw new BusinessException("böyle bir veri bulunamadı"); 

                Product mappedProduct = _mapper.Map<Product>(product);

                 await _productRepository.UpdateAsync(mappedProduct);

                UpdateProductResponse response = _mapper.Map<UpdateProductResponse>(product);

                return response;
            }
        }

    }
}
