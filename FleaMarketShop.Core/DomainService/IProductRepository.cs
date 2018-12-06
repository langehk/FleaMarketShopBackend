﻿using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.DomainService
{
    public interface IProductRepository
    {
        
        Product CreateProduct(Product product);

        Product DeleteProduct(int productId);

        Product UpdateProduct(Product productUpdate);

        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int productId);

        Product GetProductByIdIncludeImages(int productId);
    }
}
