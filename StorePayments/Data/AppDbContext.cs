using Microsoft.EntityFrameworkCore;
using ClothingStorePayments.Models;

namespace ClothingStorePayments.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Payment> Payments => Set<Payment>();
    }
}
