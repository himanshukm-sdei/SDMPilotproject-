using MediatR;
using PilotPhase.Application.Queries.ProductQuery;
using PilotPhase.Domain.Interfaces;

namespace PilotPhase.Application.Handlers.ProductHandler
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsQuery, List<Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }
}