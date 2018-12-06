using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService
{
    public interface IProductService
    {

        Product CreateProduct(Product product);

        Product DeleteProduct(int productId);

        Product UpdateProduct(Product productUpdate);

        List<Product> GetAllProducts(Filter filter);

        Product GetProductById(int productId);      
    }
}
