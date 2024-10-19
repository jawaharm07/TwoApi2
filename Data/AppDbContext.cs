using Microsoft.EntityFrameworkCore;
using TwoApi.Models;

namespace TwoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> ProductsTable { get; set; }

        
    }
}
