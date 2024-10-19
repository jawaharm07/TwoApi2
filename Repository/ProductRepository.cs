using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TwoApi.Data;
using TwoApi.Models;

namespace TwoApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task createAsync(Product product)
        {
            await _dbContext.ProductsTable.AddAsync(product);
            await _dbContext.SaveChangesAsync();
           
        }
        public async  Task<IEnumerable<Product>> GetAllAsync()
        {
           return await _dbContext.ProductsTable.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.ProductsTable.FindAsync(id);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _dbContext.ProductsTable.FindAsync($"{name}");
        }

        public async Task updateAsync(Product product)
        {
            _dbContext.ProductsTable.Update(product);
             await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _dbContext.ProductsTable.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
