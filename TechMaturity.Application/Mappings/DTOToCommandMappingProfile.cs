using System;
using AutoMapper;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Products.Commands;
using TechMaturity.Application.Products.Queries;

namespace TechMaturity.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();          
        }
    }
}

