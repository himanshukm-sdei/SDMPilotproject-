using MediatR;
using PilotPhase.Application.Commands.ContactForm;
using PilotPhase.Application.Commands.ProductCommand;
using PilotPhase.Domain.Entities;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Infrastructure.Repositories;
using PilotPhase.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Handlers.ContactFormHandler
{
    internal class DeleteContactFormCommandHandler : IRequestHandler<DeleteContactFormCommand, bool>
    {
        private readonly IContactFormRepository  _contactFormRepository;
        private readonly IEncryptionService _encryptionService;
        public DeleteContactFormCommandHandler(IContactFormRepository  contactFormRepository, IEncryptionService encryptionService)
        {
            _contactFormRepository = contactFormRepository;
            _encryptionService = encryptionService;
        }

        public async Task<bool> Handle(DeleteContactFormCommand request, CancellationToken cancellationToken)
        {
            var contactform = await _contactFormRepository.GetContactFormByIdAsync(request.Id);
            if (contactform == null) return false;

            if (contactform.IsDataDeleteConsent==true)
            {
                contactform.DeletedDate = DateTime.Now.AddMonths(2);  // Mark for deletion in 2 months
            }

            //return await _contactFormRepository.DeleteContactFormAsync(request.Id);
            return await _contactFormRepository.UpdateContactFormAsync(contactform.Id, contactform);



        }
    }
}