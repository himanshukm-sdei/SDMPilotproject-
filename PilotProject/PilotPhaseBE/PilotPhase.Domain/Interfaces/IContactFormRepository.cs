using PilotPhase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Domain.Interfaces
{
    public interface IContactFormRepository
    {
        Task<ContactForm> GetContactFormByIdAsync(string id);
        Task<List<ContactForm>> GetAllContactFormsAsync();
        Task<string> CreateContactFormAsync(ContactForm contactForm);
        Task<bool> UpdateContactFormAsync(string id, ContactForm contactForm);
        Task<bool> DeleteContactFormAsync(string id);
        //Task<bool> UpdateContactFormAsync(ContactForm existingContactForm);
    }
}
