using TwoApi.Models;
using TwoApi.Repository;

namespace TwoApi.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.createAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<Product> GetProductBYIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetProductBYNameAsync(string name)
        {
            return await _productRepository.GetByNameAsync($"{name}");
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.updateAsync(product);
        }
    }
}
