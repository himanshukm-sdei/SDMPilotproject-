﻿namespace PilotPhase.DTO.Product
{
    public class UpdateProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }     

        public DateTime? ModifiedDate { get; set; }

    }
}

