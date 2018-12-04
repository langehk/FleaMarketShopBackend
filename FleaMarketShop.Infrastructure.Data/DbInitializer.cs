using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace FleaMarketShop.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {

        private IAuthenticationHelper authenticationHelper;

        public DbInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void Initialize(FleaMarketShopContext ctx)
        {

            //make sure that the environment database is deleted and created.
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (ctx.Products.Any() || ctx.Categories.Any() || ctx.Users.Any())
            {
                return;
            }

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

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    UserName = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    UserName = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }
    }
}
