using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService.ProductDto
{
    public class ProductListDto
    {
        public int ProductID { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public DateTime? Year { get; set; }
        public double Storage { get; set; }

        public string Brand { get; set; }
        public string MaterialFrameType { get; set; }
    }
}
