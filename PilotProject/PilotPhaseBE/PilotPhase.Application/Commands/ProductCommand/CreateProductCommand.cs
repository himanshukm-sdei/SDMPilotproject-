using MediatR;
using PilotPhase.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest<string>
    {
        public ProductDTO Product { get; set; }

        public CreateProductCommand(ProductDTO product)
        {
            Product = product;
        }
    }
}
