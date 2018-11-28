using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(long userId);

        void AddUser(User user);

        void EditUser(User user);

        void DeleteUser(long userId);
    }
}
