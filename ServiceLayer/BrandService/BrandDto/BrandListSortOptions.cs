using ServiceLayer.BrandService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.BrandService.BrandDto
{
    public class BrandListSortOptions
    {
        public BrandFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
    }
}
