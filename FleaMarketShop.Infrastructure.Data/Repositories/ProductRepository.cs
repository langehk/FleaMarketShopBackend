using System;
using System.Collections.Generic;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Category CreateProduct(Category product)
        {
            throw new NotImplementedException();
        }

        public Category DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Category GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Category UpdateProduct(Category productUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
