using System;
using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().ToList();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }      

        public Product UpdateProduct(Product productUpdate)
        {
            return _productRepository.UpdateProduct(productUpdate);
        }
    }
}
