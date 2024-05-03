using AutoMapper;
using Business.Feature.Products.Commands.Create;
using Business.Feature.Products.Dtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Profiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetAllProductResponse>().ReverseMap();  

        }
    }
}
