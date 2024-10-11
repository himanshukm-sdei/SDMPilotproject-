using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Application.Commands.ContactForm
{
    public class DeleteContactFormCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteContactFormCommand(string id)
        {
            Id = id;
        }
    }
}
