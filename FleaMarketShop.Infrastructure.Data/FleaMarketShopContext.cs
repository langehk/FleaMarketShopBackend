using FleaMarketShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleaMarketShop.Infrastructure.Data
{
    public class FleaMarketShopContext : DbContext
    {
        public FleaMarketShopContext(DbContextOptions<FleaMarketShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(o => o.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasMany(o => o.Products)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.product)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductImage>()
                .HasOne(p => p.product)
                .WithMany(i => i.Images)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
