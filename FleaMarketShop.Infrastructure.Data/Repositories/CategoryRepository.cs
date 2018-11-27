using System;
using System.Collections.Generic;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByIdIncludeProducts(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category categoryUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
