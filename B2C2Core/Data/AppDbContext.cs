
using B2C2Core.Controllers;
using B2C2Core.Models;
using Microsoft.EntityFrameworkCore;

namespace B2C2Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextoptions)
            : base(contextoptions)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

    }
}
