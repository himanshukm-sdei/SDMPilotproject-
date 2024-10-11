using MediatR;
using PilotPhase.Application.Queries.ContactFormQuery;
using PilotPhase.Application.Queries.ProductQuery;
using PilotPhase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Handlers.ContactFormHandler
{
    internal class GetAllContactFormsCommandHandler : IRequestHandler<GetAllContactFormsQuery, List<Domain.Entities.ContactForm>>
    {
        private readonly IContactFormRepository  _contactFormRepository;

        public GetAllContactFormsCommandHandler(IContactFormRepository  contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public async Task<List<Domain.Entities.ContactForm>> Handle(GetAllContactFormsQuery request, CancellationToken cancellationToken)
        {
            return await _contactFormRepository.GetAllContactFormsAsync();
        }
    }
}