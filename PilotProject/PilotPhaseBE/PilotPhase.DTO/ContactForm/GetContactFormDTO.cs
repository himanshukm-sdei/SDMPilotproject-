namespace PilotPhase.DTO.ContactForm
{
    public class GetContactFormDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsDataDeleteConsent { get; set; }
        public bool? IsPrivacyPolicyConsent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
