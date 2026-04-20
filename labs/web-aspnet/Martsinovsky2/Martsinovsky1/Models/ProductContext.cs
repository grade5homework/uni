using System.Data.Entity;

namespace martsinovsky.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("martsinovsky")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}