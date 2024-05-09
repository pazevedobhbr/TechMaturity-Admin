using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Domain.Entities;

namespace TechMaturity.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Pillar, PillarDTO>().ReverseMap();
            CreateMap<Practice, PracticeDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Capability ,CapabilityDTO>().ReverseMap();
            CreateMap<Criteria, CriteriaDTO>().ReverseMap();

        }
    }
}

