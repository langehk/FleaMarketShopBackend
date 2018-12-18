using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleaMarketShop.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly FleaMarketShopContext _ctx;

        public CategoryRepository(FleaMarketShopContext ctx)
        {
            _ctx = ctx;
        }

        // Creates a category
        public Category CreateCategory(Category category)
        {
            //if (category.Products != null) _ctx.Attach(category.Products);
            var _category = _ctx.Categories.Add(category).Entity;
            _ctx.SaveChanges();
            return _category;
        }
        // Deletes a category
        public Category DeleteCategory(int categoryId)
        {
            var categoryDelete = _ctx.Remove(new Category { CategoryId = categoryId }).Entity;
            _ctx.SaveChanges();
            return categoryDelete;
        }

        //return all categories
        public IEnumerable<Category> GetAllCategories()
        {
            return _ctx.Categories;
        }

        //Get the category by id
        public Category GetCategoryById(int categoryId)
        {
            return _ctx.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

        }
        //Get the category by id, and includes the product.
        public Category GetCategoryByIdIncludeProducts(int categoryId)
        {
            return _ctx.Categories
                       .Include(c => c.Products)
                       .FirstOrDefault(c => c.CategoryId == categoryId);
        }
        //Update category
        public Category UpdateCategory(Category categoryUpdate)
        {
            _ctx.Attach(categoryUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return categoryUpdate;
        }
    }
}
