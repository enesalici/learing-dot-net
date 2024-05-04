using AutoMapper;
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

namespace Business.Feature.Products.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdProductResponse>
    {
         public int Id { get; set; }


        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdProductResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;

            public GetByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }

            public async Task<GetByIdProductResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);

                if (product == null)
                    throw new BusinessException("Böyle bir ürün bulunamadı");

                GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

                return response;
            }
        }
    }
}
