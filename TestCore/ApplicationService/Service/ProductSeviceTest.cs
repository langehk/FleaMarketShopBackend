using System;
using System.IO;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.ApplicationService.Implementations;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;
using Moq;
using Xunit;


namespace TestCore.ApplicationService.Service
{
    
    public class ProductSeviceTest
    {
        [Fact]
        public void ReadProductByIdSecureRepositoryIsCalled()
        {
            var productRepo = new Mock<IProductRepository>();
            var categoryRepo = new Mock<ICategoryRepository>();

            IProductService productService = new ProductService(productRepo.Object, categoryRepo.Object);

            var product = new Product()
            {
                ProductId = 1,
                ProductName = "Test",
                ProductPrice = 1234,
                ProductDescription = "test",
                MainPictureString = "test"
            };

            var isCalled = false;

            productRepo.Setup(x => x.GetProductById(It.IsAny<int>())).Callback(() => isCalled = true).Returns(new Product() { ProductId = 1 });

            productService.GetProductById(product.ProductId);

            Assert.True(isCalled);
        }


        [Fact]
        public void GetByIdIsBelowZero()
        {
            var productRepo = new Mock<IProductRepository>();
            var categoryRepo = new Mock<ICategoryRepository>();


            IProductService productService = new ProductService(productRepo.Object, categoryRepo.Object);


            var product = new Product()
            {
                ProductId = -1,
                ProductName = "test",
                ProductPrice = 1234,
                ProductDescription = "test",
                MainPictureString = "test"
            };

            Exception e = Assert.Throws<InvalidDataException>(() =>
                productService.GetProductById(product.ProductId));

            Assert.Equal("Enter an Id that is at least 1", e.Message);
        }


    }
}
