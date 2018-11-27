using System;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void SeedDb(FleaMarketShopContext ctx)
        {

            //make sure that the enviroment database is deleted and created.
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            var product1 = ctx.Products.Add(new Product
            {
                ProductName = "Stol",
                ProductPrice = 1234
            }).Entity;

            var product2 = ctx.Products.Add(new Product
            {
                ProductName = "Bord",
                ProductPrice = 4444
            }).Entity;



            var category1 = ctx.Categories.Add(new Category
            {
                CategoryName = "Inventar"
            }).Entity;



            var category2 = ctx.Categories.Add(new Category
            {
                CategoryName = "Have"
            }).Entity;


            var user1 = ctx.Users.Add(new User
            {
                UserName = "AdminUser"
                //PasswordHash = passwordHashUser,
                //PasswordSalt = passwordSaltUser,
                //IsAdmin = true
            }).Entity;

            ctx.SaveChanges();
        }


    }
}
