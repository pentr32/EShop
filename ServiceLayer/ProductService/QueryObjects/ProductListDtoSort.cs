using ServiceLayer.ProductService.ProductDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "Simple Order")]
        SimpleOrder,
        [Display(Name = "Sort by Model")]
        Model,
        [Display(Name = "Low Price")]
        LowPrice,
        [Display(Name = "High Price")]
        HighPrice,
        [Display(Name = "Brand")]
        Brand,
        [Display(Name = "Color")]
        Color,
        [Display(Name = "Year")]
        Year,
        [Display(Name = "Storage")]
        Storage,
        [Display(Name = "MaterialFrameType")]
        MaterialFrameType
    }

    public static class ProductListDtoSort
    {
        public static IQueryable<ProductListDto> OrderProductsBy(this IQueryable<ProductListDto> products, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return products;

                case OrderByOptions.Model:
                    return products.OrderBy(r => r.Model);

                case OrderByOptions.LowPrice:
                    return products.OrderBy(r => r.Price);

                case OrderByOptions.HighPrice:
                    return products.OrderByDescending(r => r.Price);

                case OrderByOptions.Brand:
                    return products.OrderBy(r => r.Brand);

                case OrderByOptions.Color:
                    return products.OrderBy(r => r.Color);

                case OrderByOptions.Year:
                    return products.OrderByDescending(r => r.Year);

                case OrderByOptions.Storage:
                    return products.OrderByDescending(r => r.Storage);

                case OrderByOptions.MaterialFrameType:
                    return products.OrderByDescending(r => r.MaterialFrameType);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
