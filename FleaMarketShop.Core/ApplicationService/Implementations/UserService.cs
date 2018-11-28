using System;
using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
             _userRepository.AddUser(user);
        }

        public void DeleteUser(long userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public void EditUser(User user)
        {
            _userRepository.EditUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }

        public User GetUserById(long userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
