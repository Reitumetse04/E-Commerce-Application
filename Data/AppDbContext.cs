using Microsoft.EntityFrameworkCore;
using OnlineStoreAuthAPI.Models;

namespace OnlineStoreAuthAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
