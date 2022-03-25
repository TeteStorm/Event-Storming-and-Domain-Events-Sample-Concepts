using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
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