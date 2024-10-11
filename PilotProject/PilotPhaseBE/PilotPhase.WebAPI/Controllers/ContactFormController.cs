using MediatR;
using Microsoft.AspNetCore.Mvc;
using PilotPhase.Application.Commands.ContactForm;
using PilotPhase.Application.Queries.ContactFormQuery;
using PilotPhase.DTO.ContactForm;
using PilotPhase.Shared.Messages;

namespace PilotPhase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("contact-forms")]
        public async Task<ActionResult<List<GetContactFormDTO>>> GetContactForms()
        {
            var contactForms = await _mediator.Send(new GetAllContactFormsQuery());
            return Ok(contactForms);
        }

        [HttpPost("contact")]     
        public async Task<IActionResult> CreateContactForm([FromBody] ContactFormDTO contactFormDTO)
        {
                     
            // Send the command to the handler
            var result = await _mediator.Send(new CreateContactFormCommand(contactFormDTO));

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(new { response= "Failed to create contact form." });
            }

            // Return the ID of the newly created contact form
            return Ok(new { Id = result});
        }
    

       
        [HttpPut("contact")]
        public async Task<IActionResult> UpdateContactForm( [FromBody] UpdateContactFormDTO updateContactFormDTO)
        {
            var result = await _mediator.Send(new UpdateContactFormCommand( updateContactFormDTO));

            if (result)
            {
                return Ok(new { response = Responses.RecordUpdated });
            }
            else
            {
                return NotFound(new { Responses.RecordNotFoundOrChangeDetected});
            }
        }

        [HttpDelete("contact/{id}")]
        public async Task<IActionResult> DeleteContactForm(string id)
        {
            var result = await _mediator.Send(new DeleteContactFormCommand(id));
        
            if (result)
            {
                return Ok(new { response = Responses.RecordDeleted });
            }
            else
            {
                return NotFound(new { response = Responses.RecordNotFoundOrAlreadyDeleted });
            }
        }
    }
}
