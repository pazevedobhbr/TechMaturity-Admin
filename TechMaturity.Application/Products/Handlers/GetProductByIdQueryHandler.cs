using TechMaturity.Application.Products.Queries;
using TechMaturity.Domain.Entities;
using TechMaturity.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TechMaturity.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIDAsync(request.Id);
        }
    }
}
