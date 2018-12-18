using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {

        private readonly FleaMarketShopContext _ctx;

        public ProductImageRepository(FleaMarketShopContext ctx)
        {
            _ctx = ctx;
        }
        public ProductImage CreateProductImage(ProductImage productImage)
        {
            if (productImage.product != null) _ctx.Attach(productImage.product);
            var _productImage = _ctx.ProductImages.Add(productImage).Entity;
            _ctx.SaveChanges();
            return _productImage;
        }

        public ProductImage DeleteProductImage(int id)
        {
            var productImageDelete = _ctx.Remove(new ProductImage() { ProductImageId = id }).Entity;
            _ctx.SaveChanges();
            return productImageDelete;
        }

        public ProductImage UpdateProductImage(ProductImage productImage)
        {
            _ctx.Attach(productImage).State = EntityState.Modified;
            _ctx.SaveChanges();
            return productImage;
        }

        public IEnumerable<ProductImage> GetAllProductImages()
        {
            return _ctx.ProductImages;
        }

        public ProductImage GetProductImageById(int id)
        {
            return _ctx.ProductImages.FirstOrDefault(p => p.ProductImageId == id);
        }
    }
}
