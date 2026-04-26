using System.Data.Entity;

namespace Martsinovsky1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("Martsinovsky1")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}