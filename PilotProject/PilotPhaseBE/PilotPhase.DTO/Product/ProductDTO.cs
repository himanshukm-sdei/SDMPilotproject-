namespace PilotPhase.DTO.Product
{
    public class ProductDTO
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Category { get; set; }

        public required decimal Price { get; set; }

        public bool IsActive { get; set; } = true;
       
        public DateTime? CreatedDate { get; set; }

    }


}
