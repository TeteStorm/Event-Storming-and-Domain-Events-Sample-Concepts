using OrderMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderMS.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;
    }
}