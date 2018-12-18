using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.DomainService
{
    public interface IProductImageRepository
    {
        ProductImage CreateProductImage(ProductImage productImage);

        ProductImage DeleteProductImage(int productImageId);

        ProductImage UpdateProductImage(ProductImage productImage);

        IEnumerable<ProductImage> GetAllProductImages();

        ProductImage GetProductImageById(int productImageId);
    }
}
