using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FleaMarketShopContext _ctx;

        public UserRepository(FleaMarketShopContext ctx)
        {
            _ctx = ctx;
        }

        //Creates a new user //void, doesn't return a user.
        public void AddUser(User user)
        {
            var _user = _ctx.Users.Add(user).Entity;
            _ctx.SaveChanges();

        }

        //Deletes a user  //void, dosen't return a user
        public void DeleteUser(long userId)
        {
            var userDelete = _ctx.Users.FirstOrDefault(u => u.UserId == userId);
            _ctx.Users.Remove(userDelete);
            _ctx.SaveChanges();

        }
        //Update a user //void, doesn't return a user
        public void EditUser(User user)
        {
            var _userEdit = _ctx.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ctx.SaveChanges();

        }
        //Return all users
        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }
        //Return the user by id
        public User GetUserById(long userId)
        {
            return _ctx.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
