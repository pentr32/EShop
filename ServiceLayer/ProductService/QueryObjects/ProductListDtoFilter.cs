using ServiceLayer.ProductService.ProductDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace ServiceLayer.ProductService.QueryObjects
{
    public enum ProductFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By Brand")]
        ByBrand,
        [Display(Name = "By MaterialFrameType")]
        ByMaterialFrameType
    }

    public static class ProductListDtoFilter
    {
        public static IQueryable<ProductListDto> FilterProductsBy(this IQueryable<ProductListDto> products, ProductFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue)) return products;

            switch (filterBy)
            {
                case ProductFilterBy.NoFilter:
                    return products;

                case ProductFilterBy.ByBrand:
                    return products.Where(p => p.Brand.StartsWith(filterValue));

                case ProductFilterBy.ByMaterialFrameType:
                    return products.Where(p => p.MaterialFrameType.StartsWith(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
