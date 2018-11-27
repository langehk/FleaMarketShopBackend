using System;
namespace FleaMarketShop.Core.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
