using System;

namespace FleaMarketShop.Core.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public String Image { get; set; }
        public Product product { get; set; }
    }
}
