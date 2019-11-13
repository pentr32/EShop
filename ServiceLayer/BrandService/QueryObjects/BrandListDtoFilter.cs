using ServiceLayer.BrandService.BrandDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
    public enum BrandFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By ProductID")]
        ByBrandID,
        [Display(Name = "By BrandName")]
        ByBrandName
    }

    public static class BrandListDtoFilter
    {
        public static IQueryable<BrandListDto> FilterBrandBy(this IQueryable<BrandListDto> brands, BrandFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue)) return brands;

            switch (filterBy)
            {
                case BrandFilterBy.NoFilter:
                    return brands;

                case BrandFilterBy.ByBrandID:
                    return brands.Where(b => b.BrandID == Convert.ToInt32(filterValue));

                case BrandFilterBy.ByBrandName:
                    return brands.Where(b => b.Name.StartsWith(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
