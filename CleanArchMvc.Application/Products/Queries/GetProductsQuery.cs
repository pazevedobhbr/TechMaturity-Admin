using System;
using TechMaturity.Domain.Entities;
using MediatR;

namespace TechMaturity.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}

