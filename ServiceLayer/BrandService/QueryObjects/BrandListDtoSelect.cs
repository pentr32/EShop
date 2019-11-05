using DataLayer.Entities;
using ServiceLayer.BrandService.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
    public static class BrandListDtoSelect
    {
        public static IQueryable<BrandListDto> MapBrandToDto(this IQueryable<Brand> brands)
        {
            return brands.Select(b => new BrandListDto
            {
                BrandID = b.BrandID,
                Name = b.Name,
                LogoName = b.LogoName
            });
        }
    }
}
