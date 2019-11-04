using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayer.ProductService.ProductDto;

namespace ServiceLayer.ProductService.QueryObjects
{
    public static class ProductListDtoSelect
    {
        public static IQueryable<ProductListDto> MapProductToDto(this IQueryable<Product> products)
        {
            return products.Select(p => new ProductListDto
            {
                ProductID = p.ProductID,
                Model = p.Model,
                Price = p.Price,
                Color = p.Color,
                ImageName = p.ImageName,
                Description = p.Description,
                Year = p.Year,
                Storage = p.Storage,
                Brand = p.Brand.Name,
                MaterialFrameType = p.MaterialFrameType.Type
            });
        }
    }
}
