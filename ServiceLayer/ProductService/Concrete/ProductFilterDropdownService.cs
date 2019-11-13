using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public class ProductFilterDropdownService : IProductFilterDropdownService
    {
        private readonly EShopContext _context;

        public ProductFilterDropdownService(EShopContext context)
        {
            _context = context;
        }

        public IEnumerable<DropdownTuple> GetFilterDropDownValues(ProductFilterBy filterBy)
        {
            switch (filterBy)
            {
                case ProductFilterBy.NoFilter:
                    return new List<DropdownTuple>();

                case ProductFilterBy.ByBrand:
                    var queryBrand = _context.Products
                        .Include(p => p.Brand)
                        .Where(p => p.BrandID != null)
                        .OrderBy(p => p.Brand.Name)
                        .Select(p => new DropdownTuple
                        {
                            Value = p.BrandID.ToString(),
                            Text = p.Brand.Name
                        }).ToList();
                    return queryBrand;

                case ProductFilterBy.ByMaterialFrameType:
                    var queryMaterial = _context.Products
                        .Include(p => p.MaterialFrameType)
                        .Where(p => p.MaterialFrameTypeID != null)
                        .OrderBy(p => p.MaterialFrameType.Type)
                        .Select(p => new DropdownTuple
                        {
                            Value = p.MaterialFrameTypeID.ToString(),
                            Text = p.MaterialFrameType.Type
                        });
                    return queryMaterial;

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
