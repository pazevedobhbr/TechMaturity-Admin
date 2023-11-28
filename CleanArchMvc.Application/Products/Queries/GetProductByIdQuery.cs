using System;
using TechMaturity.Domain.Entities;
using MediatR;

namespace TechMaturity.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}

