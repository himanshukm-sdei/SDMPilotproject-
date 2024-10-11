using MediatR;
using PilotPhase.Application.Commands.ContactForm;
using PilotPhase.Domain.Entities;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Handlers.ContactFormHandler
{
    public class CreateContactFormCommandHandler : IRequestHandler<CreateContactFormCommand, string>
    {
        private readonly IContactFormRepository _repository;
        private readonly IEncryptionService _encryptionService;

        public CreateContactFormCommandHandler(IContactFormRepository repository, IEncryptionService encryptionService)
        {
            _repository = repository;
            _encryptionService = encryptionService;
        }

        public async Task<string> Handle(CreateContactFormCommand request, CancellationToken cancellationToken)
        {
            var contactForm = new ContactForm
            {
                Name = _encryptionService.Encrypt(request.ContactForm.Name),
                Email = _encryptionService.Encrypt(request.ContactForm.Email),
                Message = _encryptionService.Encrypt(request.ContactForm.Message),
                IsActive = true,
                IsPrivacyPolicyConsent = request.ContactForm.IsPrivacyPolicyConsent,
                IsDataDeleteConsent = request.ContactForm.IsDataDeleteConsent,
                CreatedDate = DateTime.Now,
            };

            await _repository.CreateContactFormAsync(contactForm);
            return contactForm.Id;
        }
    }
}
