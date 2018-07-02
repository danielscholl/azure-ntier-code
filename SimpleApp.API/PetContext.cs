using Microsoft.EntityFrameworkCore;
using SimpleApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.API
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
