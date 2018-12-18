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
    [ApiController]
    public class ProductImageController : Controller
    {

        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        // GET: api/ProductImage
        [HttpGet]
        public ActionResult<IEnumerable<ProductImage>> Get()
        {
            try
            {
                return Ok(_productImageService.GetAllProductImages().ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/ProductImage/5
        [HttpGet("{id}")]
        public ActionResult<ProductImage> Get(int id)
        {
            return _productImageService.GetProductImageById(id);
        }

        // POST: api/ProductImage
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<ProductImage> Post([FromBody]ProductImage productImage)
        {
            return _productImageService.CreateProductImage(productImage);
        }

        // PUT: api/ProductImage/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<ProductImage> Put(int id, [FromBody] ProductImage productImage)
        {
            return _productImageService.UpdateProductImage(productImage);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<ProductImage> Delete(int id)
        {
            return _productImageService.DeleteProductImage(id);
        }
    }
}
