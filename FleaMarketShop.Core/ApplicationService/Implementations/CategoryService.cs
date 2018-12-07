using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;

namespace FleaMarketShop.Core.ApplicationService.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CreateCategory(Category category)
        {
            //Category name
            if (string.IsNullOrEmpty(category.CategoryName))
            {
                throw new InvalidDataException("Can not create a category without a name");
            }

            return _categoryRepository.CreateCategory(category);
        }

        public Category DeleteCategory(int categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories().ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            if (categoryId <=0)
            {
                throw new InvalidDataException("Enter an Id that is a least 1");
            }
            if (_categoryRepository.GetCategoryById(categoryId) == null)
            {
                throw new Exception("Could not find any Category with the entered id");
            }
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public Category GetCategoryByIdIncludeProducts(int categoryId)
        {
            return _categoryRepository.GetCategoryByIdIncludeProducts(categoryId);
        }

        public Category UpdateCategory(Category categoryUpdate)
        {
            return _categoryRepository.UpdateCategory(categoryUpdate);
        }
    }
}
