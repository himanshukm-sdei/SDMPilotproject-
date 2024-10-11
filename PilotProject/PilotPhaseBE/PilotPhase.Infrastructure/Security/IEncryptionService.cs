using PilotPhase.Domain.Entities;

namespace PilotPhase.Infrastructure.Security
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);

        ContactForm DecryptContactForm(ContactForm contactForm);
    }
}
