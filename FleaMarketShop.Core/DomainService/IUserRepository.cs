using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(long userId);     
        //Void grundet vi ikke returner i vores UserRepository.
        void EditUser(User user);
        void DeleteUser(long userId);
        void AddUser(User user);
    }
}
