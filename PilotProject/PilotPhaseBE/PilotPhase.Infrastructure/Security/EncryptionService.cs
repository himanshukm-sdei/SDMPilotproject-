using Microsoft.Extensions.Configuration;
using PilotPhase.Domain.Entities;
using System.Security.Cryptography;
using System.Text;


namespace PilotPhase.Infrastructure.Security
{
    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptionService(IConfiguration configuration)
        {
            // Load the AES encryption key and IV from the configuration
            _key = Encoding.UTF8.GetBytes(configuration["AES:Key"]);
            _iv = Encoding.UTF8.GetBytes(configuration["AES:IV"]);

            // Validate key and IV length
            if (_key.Length != 32)
                throw new ArgumentException("AES encryption key must be 32 bytes (256 bits).");
            if (_iv.Length != 16)
                throw new ArgumentException("AES IV must be 16 bytes (128 bits).");
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    var encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }


        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            var cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (var msDecrypt = new MemoryStream(cipherBytes))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    var plaintext = srDecrypt.ReadToEnd();
                    return plaintext;
                }
            }
        }

        public ContactForm DecryptContactForm(ContactForm contactForm)
        {
            // Decrypt only fields that are encrypted (e.g., name, email, message)
            contactForm.Name = DecryptIfEncrypted(contactForm.Name);
            contactForm.Email = DecryptIfEncrypted(contactForm.Email);
            contactForm.Message = DecryptIfEncrypted(contactForm.Message);

            // Other fields (like id, isActive, etc.) remain unchanged
            return contactForm;
        }

        private string DecryptIfEncrypted(string encryptedField)
        {
            // Simple check to determine if the field is encrypted (basic base64 check)
            if (!string.IsNullOrEmpty(encryptedField) && encryptedField.EndsWith("="))
            {
                try
                {
                    return Decrypt(encryptedField);
                }
                catch
                {
                    // If decryption fails, assume it's not actually encrypted
                    return encryptedField;
                }
            }

            return encryptedField; // Return as-is if it's not encrypted
        }
    }
}
