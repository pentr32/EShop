using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService.ProductDto
{
    public class ProductListSortOptions
    {
        public OrderByOptions OrderByOptions { get; set; }
        public ProductFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
    }
}
