using TwoApi.Models;

namespace TwoApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductBYIdAsync(int id);
        Task<Product> GetProductBYNameAsync(string name);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
