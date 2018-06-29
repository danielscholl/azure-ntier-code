using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess.Models;

namespace SimpleApp.DataAccess
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions<AdContext> options)
            : base(options)
        {

        }

        public DbSet<Ad> Ads { get; set; }
    }
}
