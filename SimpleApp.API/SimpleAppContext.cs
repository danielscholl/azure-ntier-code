using Microsoft.EntityFrameworkCore;
using SimpleApp.API.Models;

namespace SimpleApp.API
{
    public class SimpleAppContext : DbContext
    {
        public SimpleAppContext(DbContextOptions<SimpleAppContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Pet> Pets { get; set; }
    }
}
