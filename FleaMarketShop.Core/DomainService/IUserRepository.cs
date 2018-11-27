using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(long userId);
        User AddUser(User user);
        User EditUser(User user);
        User DeleteUser(long userId);
    }
}
