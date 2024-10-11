using MediatR;
using PilotPhase.Application.Commands.ContactForm;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Handlers.ContactFormHandler
{
    public class UpdateContactFormCommandHandler : IRequestHandler<UpdateContactFormCommand, bool>
    {
        private readonly IContactFormRepository _contactFormRepository;
        private readonly IEncryptionService _encryptionService;

        public UpdateContactFormCommandHandler(IContactFormRepository contactFormRepository, IEncryptionService encryptionService)
        {
            _contactFormRepository = contactFormRepository;
            _encryptionService = encryptionService;
        }

        public async Task<bool> Handle(UpdateContactFormCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing contact form by Id
            var existingContactForm = await _contactFormRepository.GetContactFormByIdAsync(request.ContactForm.Id);
            if (existingContactForm == null)
            {
                return false; // Return false if the contact form does not exist
            }

            // Encrypt sensitive fields before updating
            var encryptedName = _encryptionService.Encrypt(request.ContactForm.Name);
            var encryptedEmail = _encryptionService.Encrypt(request.ContactForm.Email);
            var encryptedMessage = _encryptionService.Encrypt(request.ContactForm.Message);

            // Update the contact form fields
            existingContactForm.Name = encryptedName;
            existingContactForm.Email = encryptedEmail;
            existingContactForm.Message = encryptedMessage;
            existingContactForm.ModifiedDate = request.ContactForm.ModifiedDate ?? DateTime.Now; // Set modified date to current if not provided

            // Save the updated contact form
            var result = await _contactFormRepository.UpdateContactFormAsync(request.ContactForm.Id,existingContactForm);

            return result;
        }
    }
}
