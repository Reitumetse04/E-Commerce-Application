using Microsoft.EntityFrameworkCore;
using ClearCartApi.Models;

namespace ClearCartApi.Database
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
    }
}

