using Microsoft.EntityFrameworkCore;
namespace Project.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}