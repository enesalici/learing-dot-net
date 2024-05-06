using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }


        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
        {
            private readonly IProductRepository _productRepository;

            public DeleteProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await  _productRepository.GetAsync(p => p.Id == request.Id);

                if (product == null)
                    throw new BusinessException("böyle bir ürün yok");

                await _productRepository.DeleteAsync(product);
            }
        }
    }
}
