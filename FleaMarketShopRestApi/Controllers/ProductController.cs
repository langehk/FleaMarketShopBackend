using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductById(id);
        }

        // POST api/product
        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product)
        {
            return _productService.CreateProduct(product);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody]Product product)
        {
            return _productService.UpdateProduct(product);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}
