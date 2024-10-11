using MediatR;
using PilotPhase.Application.Commands.ProductCommand;
using PilotPhase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Handlers.ProductHandler
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null) return false;


            product.IsActive = false;
            product.DeletedDate = DateTime.Now;
            return await _productRepository.UpdateProductAsync(product.Id, product);

            //await _productRepository.DeleteProductAsync(request.Id);
            //return true;
        }
    }
}