using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Domain.Entities;

namespace TechMaturity.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

