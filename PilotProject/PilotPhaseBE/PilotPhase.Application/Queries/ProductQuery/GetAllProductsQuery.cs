using MediatR;
using PilotPhase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Queries.ProductQuery
{
    public class GetAllProductsQuery : IRequest<List<Domain.Entities.Product>>
    {

    }
}
