using MediatR;
using PilotPhase.DTO.ContactForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Commands.ContactForm
{
    public class CreateContactFormCommand : IRequest<string>
    {
        public ContactFormDTO ContactForm { get; set; }

        public CreateContactFormCommand(ContactFormDTO contactForm)
        {
            ContactForm = contactForm;
        }

    }
}
