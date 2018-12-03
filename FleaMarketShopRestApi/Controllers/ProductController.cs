using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.GetAllProducts().ToList();
        }

        // GET api/product/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductById(id);
        }

        // POST api/product
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product)
        {
            return _productService.CreateProduct(product);
        }

        // PUT api/product/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody]Product product)
        {
            return _productService.UpdateProduct(product);
        }

        // DELETE api/product/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}
