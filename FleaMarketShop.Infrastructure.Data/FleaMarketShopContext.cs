using System;
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

    }
}
