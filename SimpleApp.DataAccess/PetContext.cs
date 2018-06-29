using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess.Models;

namespace SimpleApp.DataAccess
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

    }
}
