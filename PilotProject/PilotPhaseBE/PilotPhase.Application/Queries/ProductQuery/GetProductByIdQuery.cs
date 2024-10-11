using MediatR;
using PilotPhase.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Queries.Product
{
    public class GetProductByIdQuery : IRequest<GetProductDTO>
    {
        public string Id { get; }

        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
    }


}
