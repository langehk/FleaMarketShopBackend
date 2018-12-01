using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;
using FleaMarketShopRestApi.Helpers;
using FleaMarketShopRestApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FleaMarketShopRestApi.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly IUserService _userService;

        private readonly IAuthenticationHelper _authenticationHelper;

        public TokenController(IUserService userService, IAuthenticationHelper authService)
        {
            _userService = userService;
            _authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInput model)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(u => u.UserName == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.UserName,
                token = _authenticationHelper.GenerateToken(user)
            });
        }

    }
}
