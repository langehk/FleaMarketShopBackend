using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Product CreateProduct(Product product)
        {
            //ProductName
            if (string.IsNullOrEmpty(product.ProductName))
            {
                throw new InvalidDataException("Can not create a product without a name");
            }
            //ProductPrice
            else if (product.ProductPrice <= 0)
            {
                throw new InvalidDataException("Can not create a product without a price");
            }
            //ProductDescription
            else if (string.IsNullOrEmpty(product.ProductDescription))
            {
                throw new InvalidDataException("Can not create a product without a description");
            }

            return _productRepository.CreateProduct(product);
        }


        public Product DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts(Filter filter)
        {
            if (filter.ItemsPrPage < 0 || filter.CurrentPage < 0)
            {
                throw new Exception("Please enter values that are at least 0");
            }

            return _productRepository.GetAllProducts(filter).ToList();
        }

        public Product GetProductById(int productId)
        {
            if (productId <= 0)
            {
                throw new InvalidDataException("Enter an Id that is at least 1");
            }

            if (_productRepository.GetProductById(productId) == null)
            {
                throw new Exception("Could not find any User with the entered id");
            }

            return _productRepository.GetProductById(productId);
        }      

        public Product UpdateProduct(Product productUpdate)
        {
            return _productRepository.UpdateProduct(productUpdate);
        }
    }
}
