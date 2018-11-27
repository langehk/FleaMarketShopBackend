using System;
using System.Collections.Generic;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService
{
    public interface ICategoryService 
    {
        Category CreateCategory(Category category);

        Category DeleteCategory(int categoryId);

        Category UpdateCategory(Category categoryUpdate);

        List<Category> GetAllCategories();

        Category GetCategoryById(int categoryId);

    }
}
