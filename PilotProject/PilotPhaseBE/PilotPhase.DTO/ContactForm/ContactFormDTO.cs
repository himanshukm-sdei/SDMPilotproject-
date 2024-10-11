namespace PilotPhase.DTO.ContactForm
{
    public class ContactFormDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }        
        public bool? IsDataDeleteConsent { get; set; }
        public bool? IsPrivacyPolicyConsent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
