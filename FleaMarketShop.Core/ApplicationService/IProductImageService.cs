using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService
{
    public interface IProductImageService
    {
        ProductImage CreateProductImage(ProductImage productImage);

        ProductImage DeleteProductImage(int productImageId);

        ProductImage UpdateProductImage(ProductImage productImage);

        List<ProductImage> GetAllProductImages();

        ProductImage GetProductImageById(int productImageId);     
    }
}
