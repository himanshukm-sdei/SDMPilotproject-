using MongoDB.Driver;
using PilotPhase.Domain.Entities;
using PilotPhase.Domain.Interfaces;

namespace PilotPhase.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("ProductDatabase");
            _products = database.GetCollection<Product>("Products");

            // Create a compound index on Category and Price
            var keys = Builders<Product>.IndexKeys.Ascending(p => p.Category).Descending(p => p.Price);
            _products.Indexes.CreateOne(new CreateIndexModel<Product>(keys));
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _products.Find(p => p.IsActive==true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            return await _products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<string> CreateProductAsync(Product product)
        {
            await _products.InsertOneAsync(product);
            return product.Id;
        }

        public async Task<bool> UpdateProductAsync(string id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var result = await _products.ReplaceOneAsync(filter, product);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

      
        public async Task<bool> DeleteProductAsync(string id)
        {
            // Use Builders to set the IsDeleted flag to true
            var updateDefinition = Builders<Product>.Update
                .Set(p => p.IsActive, false)
                .Set(p => p.ModifiedDate, DateTime.Now); // Optionally update ModifiedDate

            // Perform the update and check the result
            var result = await _products.UpdateOneAsync(
                p => p.Id == id && p.IsActive == true,  // Ensure we are soft deleting a non-deleted product
                updateDefinition
            );

            // Return true if the document was modified
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}