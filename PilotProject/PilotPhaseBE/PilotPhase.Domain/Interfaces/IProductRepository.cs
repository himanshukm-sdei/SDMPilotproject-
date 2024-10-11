using PilotPhase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotPhase.Domain.Interfaces
{
    public interface IProductRepository
    {             
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<string> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(string id, Product product);
        Task<bool>  DeleteProductAsync(string id);
    }
}
