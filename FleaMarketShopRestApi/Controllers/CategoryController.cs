using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarketShopRestApi.Controllers
{
    
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _categoryService.GetAllCategories().ToList();        
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Category> Post([FromBody]Category category)
        {
            return _categoryService.CreateCategory(category);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category category)
        {
            return _categoryService.UpdateCategory(category);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
           return _categoryService.DeleteCategory(id);
        }
    }
}
