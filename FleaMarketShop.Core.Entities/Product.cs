using System;
using System.Collections.Generic;

namespace FleaMarketShop.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public List<Category> Categories { get; set; }

    }
}
