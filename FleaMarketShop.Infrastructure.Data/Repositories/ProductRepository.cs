using System;
using System.Collections.Generic;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FleaMarketShopContext _ctx;

        public ProductRepository(FleaMarketShopContext ctx)
        {
            _ctx = ctx;
        }

        // Creates a product
        public Product CreateProduct(Product product)
        {
            if (product.Categories != null) _ctx.Attach(product.Categories);
            var _product = _ctx.Products.Add(product).Entity;
            _ctx.SaveChanges();
            return _product;
        }

        // Deletes a product
        public Product DeleteProduct(int productId)
        {
            var productDelete = _ctx.Remove(new Product {ProductId = productId}).Entity;
            _ctx.SaveChanges();
            return productDelete;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product productUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
