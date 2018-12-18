using System.Linq;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Infrastructure.Data;
using FleaMarketShopRestApi.Models;
using Microsoft.AspNetCore.Mvc;


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
