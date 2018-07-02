using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
