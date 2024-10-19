using TwoApi.Models;
namespace TwoApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByNameAsync(string name);
        Task createAsync(Product product);
        Task updateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
