using MongoDB.Driver;
using PilotPhase.Domain.Entities;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Infrastructure.Security;

namespace PilotPhase.Infrastructure.Repositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly IMongoCollection<ContactForm> _collection;
        private readonly IEncryptionService _encryptionService;

        public ContactFormRepository(IMongoClient mongoClient, IEncryptionService encryptionService)
        {
            var database = mongoClient.GetDatabase("ProductDatabase");
            _collection = database.GetCollection<ContactForm>("ContactForms");
            _encryptionService = encryptionService;

            // Ensure a compound index on Name and Email
            var indexKeys = Builders<ContactForm>.IndexKeys
                .Ascending(c => c.Name)
                .Ascending(c => c.Email);
            _collection.Indexes.CreateOne(new CreateIndexModel<ContactForm>(indexKeys));
        }

        public async Task<string> CreateContactFormAsync(ContactForm contactForm)
        {
            // Encrypt sensitive fields
            contactForm.Name = _encryptionService.Encrypt(contactForm.Name);
            contactForm.Email = _encryptionService.Encrypt(contactForm.Email);
            contactForm.Message = _encryptionService.Encrypt(contactForm.Message);

            contactForm.IsActive = true;
            contactForm.CreatedDate = DateTime.Now;
            contactForm.IsPrivacyPolicyConsent = contactForm.IsPrivacyPolicyConsent;
            contactForm.IsDataDeleteConsent = contactForm.IsDataDeleteConsent;
            await _collection.InsertOneAsync(contactForm);

            return contactForm.Id;
        }

        public async Task<List<ContactForm>> GetAllContactFormsAsync()
        {
            var forms = await _collection.Find(c => c.IsActive == true).ToListAsync();

            // Decrypt sensitive fields
            foreach (var form in forms)
            {
                form.Name = _encryptionService.Decrypt(form.Name);
                form.Email = _encryptionService.Decrypt(form.Email);
                form.Message = _encryptionService.Decrypt(form.Message);
                var decryptedContactForm = _encryptionService.DecryptContactForm(form);
            }

                                 
          

            return forms;
        }

        public async Task<ContactForm> GetContactFormByIdAsync(string id)
        {
            var form = await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
            if (form == null) return null;

            // Decrypt sensitive fields
            form.Name = _encryptionService.Decrypt(form.Name);
            form.Email = _encryptionService.Decrypt(form.Email);
            form.Message = _encryptionService.Decrypt(form.Message);

            return form;
        }

        public async Task<bool> UpdateContactFormAsync(string id, ContactForm contactForm)        {
            
            // Encrypt sensitive fields before updating
            var encryptedName = _encryptionService.Encrypt(contactForm.Name);
            var encryptedEmail = _encryptionService.Encrypt(contactForm.Email);
            var encryptedMessage = _encryptionService.Encrypt(contactForm.Message);

            // Use Builders to specify which fields to update
            var updateDefinition = Builders<ContactForm>.Update
                .Set(c => c.Name, encryptedName)
                .Set(c => c.Email, encryptedEmail)
                .Set(c => c.Message, encryptedMessage)
                .Set(c => c.ModifiedDate, contactForm.ModifiedDate ?? DateTime.Now);

            // Perform the update and check the result
            var result = await _collection.UpdateOneAsync(
                c => c.Id == contactForm.Id,
                updateDefinition
            );

            // Return true if at least one document was modified
            return result.ModifiedCount > 0;
        }

       public async Task<bool> DeleteContactFormAsync(string id)
        {
            // Use Builders to set the IsActive flag to false
            var updateDefinition = Builders<ContactForm>.Update
                .Set(c => c.IsActive, false)
                .Set(c => c.ModifiedDate, DateTime.Now); // Optionally set the ModifiedDate

            // Perform the update and check the result
            var result = await _collection.UpdateOneAsync(
                c => c.Id == id && c.IsActive == false, // Ensure we are updating a non-deleted document
                updateDefinition
            );

            // Return true if the document was modified
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

    }
}