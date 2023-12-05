using System;
using TechMaturity.Domain.Entities;
using MediatR;

namespace TechMaturity.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set;  }
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}

