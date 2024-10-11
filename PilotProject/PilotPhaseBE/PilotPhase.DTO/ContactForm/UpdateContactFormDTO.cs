namespace PilotPhase.DTO.ContactForm
{
    public class UpdateContactFormDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool? IsDataDeleteConsent { get; set; }
        public bool? IsPrivacyPolicyConsent { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
