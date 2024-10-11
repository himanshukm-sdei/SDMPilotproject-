using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PilotPhase.Domain.Entities
{

    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }       
        public  string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }     
        public bool IsActive { get; set; } = true;        
        public DateTime? CreatedDate { get; set; } = DateTime.Now;      
        public DateTime? ModifiedDate { get; set; }     
        public DateTime? DeletedDate { get; set; }


    }
}
