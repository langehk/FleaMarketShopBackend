using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

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
            if (product.Category != null) _ctx.Attach(product.Category);
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
        //Returns all products
        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products;
        }
        //Get the product by id
        public Product GetProductById(int productId)
        {
            return _ctx.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public Product GetProductByIdIncludeImages(int productId)
        {
            return _ctx.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.ProductId == productId);          
        }

        //update product
        public Product UpdateProduct(Product productUpdate)
        {
            _ctx.Attach(productUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return productUpdate;
        }
    }
}
