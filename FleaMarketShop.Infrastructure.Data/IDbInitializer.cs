namespace FleaMarketShop.Infrastructure.Data
{     
        public interface IDbInitializer
        {
            void Initialize(FleaMarketShopContext context);
        }
}


