using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotPhase.DTO.Product;

namespace PilotPhase.Application.Commands.ProductCommand
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductDTO Product { get; set; }

        public UpdateProductCommand(UpdateProductDTO product)
        {
            Product = product;
        }

    }
}
