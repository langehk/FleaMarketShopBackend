using System;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.ApplicationService.Implementations;
using FleaMarketShop.Core.DomainService;
using Xunit;
using Moq;
using FleaMarketShop.Core.Entities;

namespace TestCore.ApplicationService.Service
{
    public class ProductServiceTest
    {
        
        [Fact]
        public void CreateProductSecureRepositoryIsCalled()
        {

            product = new Mock<IProductRepository>();
            categoryRepo = new Mock<ICategoryRepository>();

            IProductService productService = new ProductService(productRepo.Object, categoryRepo.Object);

            var product = new Product();

            Exception e = Assert.Throws<InvalidDataException>(() =>
                productService.CreateProduct(product));

        }
    }
}
