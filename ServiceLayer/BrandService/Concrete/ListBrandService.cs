using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.Concrete
{
    public class ListBrandService
    {
        private readonly EShopContext _context;
        public ListBrandService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<BrandListDto> SortFilterPage()
        {
            var query = _context.Brands
                .AsNoTracking()
                .MapBrandToDto();
            return query;
        }
    }
}
