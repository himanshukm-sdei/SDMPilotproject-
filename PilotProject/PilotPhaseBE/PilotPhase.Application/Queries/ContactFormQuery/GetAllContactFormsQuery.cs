using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Queries.ContactFormQuery
{
    public  class GetAllContactFormsQuery : IRequest<List<Domain.Entities.ContactForm>>
    {
    }
}
