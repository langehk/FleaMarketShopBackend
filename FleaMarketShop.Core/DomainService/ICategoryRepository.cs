using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.DomainService
{
    public interface ICategoryRepository
    {


        Category CreateCategory(Category category);

        Category DeleteCategory(int categoryId);

        Category UpdateCategory(Category categoryUpdate);

        IEnumerable<Category> GetAllCategories();

        Category GetCategoryById(int categoryId);

        Category GetCategoryByIdIncludeProducts(int categoryId);
    }
}
