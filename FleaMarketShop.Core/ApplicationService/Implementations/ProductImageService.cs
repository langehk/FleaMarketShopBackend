using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService.Implementations
{
    public class ProductImageService : IProductImageService
    {

        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public ProductImage CreateProductImage(ProductImage productImage)
        {
            return _productImageRepository.CreateProductImage(productImage);
        }

        public ProductImage DeleteProductImage(int productImageId)
        {
            return _productImageRepository.DeleteProductImage(productImageId);
        }

        public ProductImage UpdateProductImage(ProductImage productImage)
        {
            return _productImageRepository.UpdateProductImage(productImage);
        }

        public List<ProductImage> GetAllProductImages()
        {
           return _productImageRepository.GetAllProductImages().ToList();
        }

        public ProductImage GetProductImageById(int id)
        {
           return _productImageRepository.GetProductImageById(id);
        }
    }
}
