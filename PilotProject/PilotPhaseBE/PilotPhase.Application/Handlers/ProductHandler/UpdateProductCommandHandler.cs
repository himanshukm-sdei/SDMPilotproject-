using MediatR;
using PilotPhase.Application.Commands.ProductCommand;
using PilotPhase.Domain.Interfaces;

namespace PilotPhase.Application.Handlers.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {


        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing product
            var existingProduct = await _productRepository.GetProductByIdAsync(request.Product.Id);
            if (existingProduct == null)
            {
                return false; // Product not found
            }


            existingProduct.Name = request.Product.Name;
            existingProduct.Description = request.Product.Description;
            existingProduct.Category = request.Product.Category;
            existingProduct.Price = request.Product.Price;
            //existingProduct.ModifiedBy = 1;
            existingProduct.ModifiedDate = DateTime.Now;


            return await _productRepository.UpdateProductAsync(existingProduct.Id, existingProduct);
        }
    }
}
