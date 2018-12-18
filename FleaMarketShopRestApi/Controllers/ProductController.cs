using System;
using System.Collections.Generic;
using System.Linq;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarketShopRestApi.Controllers
{
    [Route("api/[controller]")]

    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_productService.GetAllProducts(filter).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/product/5
        //[Authorize]
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductByIdIncludeImages(id);
            //return _productService.GetProductById(id);
        }

        // POST api/product
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product)
        {
            try
            {
                return Ok(_productService.CreateProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/product/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody]Product product)
        {

            try
            {
                return Ok(_productService.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/product/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            try
            {
                return Ok(_productService.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
