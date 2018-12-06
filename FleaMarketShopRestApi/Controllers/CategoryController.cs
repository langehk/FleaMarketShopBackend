using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                return Ok(_categoryService.GetAllCategories().ToList()); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
                   
        }

        // GET api/category/5
        //[Authorize]
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                return Ok(_categoryService.GetCategoryByIdIncludeProducts(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/category
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Category> Post([FromBody]Category category)
        {
            try
            {
                return Ok(_categoryService.CreateCategory(category));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/category/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category category)
        {
            try
            {
                return _categoryService.UpdateCategory(category);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/category/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            try
            {
                return Ok(_categoryService.DeleteCategory(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
