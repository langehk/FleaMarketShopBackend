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
    public class CategoryServiceTest
    {

        [Fact]
        public void CreateCategoryWithMissingCategoryNameExcption()
        {
            var categoryRepo = new Mock<ICategoryRepository>();
            var productRepo = new Mock<IProductRepository>();

            ICategoryService categoryService = new CategoryService(categoryRepo.Object);

            var category = new Category()
            {
                CategoryId = 1
            };

            Exception exception = Assert.Throws<InvalidDataException>(() =>
                                                                      categoryService.CreateCategory(category));

            Assert.Equal("Can not create a category without a name", exception.Message);
        }
    }
}
