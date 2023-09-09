using emenu.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace emenu.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VariantValue> VariantValues { get; set; }
        public DbSet<ProductDetails> ProductDetailss { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
