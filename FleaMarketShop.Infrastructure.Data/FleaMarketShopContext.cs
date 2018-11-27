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


        public DbSet<Category> Products { get; set; }

    }
}
