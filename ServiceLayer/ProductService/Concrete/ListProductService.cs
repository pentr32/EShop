using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public class ListProductService
    {
        private readonly EShopContext _context;
        public ListProductService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<ProductListDto> SortFilterPage(ProductListSortOptions option)
        {
            var query = _context.Products
                .AsNoTracking()
                .MapProductToDto()
                .OrderProductsBy(option.OrderByOptions)
                .FilterProductsBy(option.FilterBy, option.FilterValue);
            return query;
        }
    }
}
