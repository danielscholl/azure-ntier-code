using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess.Models;

namespace SimpleApp.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
