using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCommon
{
    public class AdsContext : DbContext
    {
        public AdsContext(DbContextOptions<AdsContext> options) : base(options)
        { }

        public AdsContext()
        {
        }

        public DbSet<Ad> Ads { get; set; }
    }
}
