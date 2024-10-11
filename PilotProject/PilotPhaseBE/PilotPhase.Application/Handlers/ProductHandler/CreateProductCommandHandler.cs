using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Domain.Entities;
using PilotPhase.DTO;
using PilotPhase.Application.Commands.ProductCommand;


namespace PilotPhase.Application.Handlers.ProductHandler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.Product.Name,
                Description = request.Product.Description,
                Category = request.Product.Category,
                Price = request.Product.Price,
                CreatedDate = DateTime.Now
            };

            await _productRepository.CreateProductAsync(product);
            return product.Id;
        }
    }
}