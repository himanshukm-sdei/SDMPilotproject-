using MediatR;
using PilotPhase.DTO.ContactForm;

namespace PilotPhase.Application.Commands.ContactForm
{
    public class UpdateContactFormCommand : IRequest<bool>
    {
      
        public UpdateContactFormDTO ContactForm { get; set; }

        public UpdateContactFormCommand(UpdateContactFormDTO contactForm)
        {
            ContactForm = contactForm;
        }
    }
}
