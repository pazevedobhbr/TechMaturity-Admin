﻿using System;
using AutoMapper;
using CleanArchMvc.Application.DTOS;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomianToDTOMappingProfile : Profile
    {
        public DomianToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

