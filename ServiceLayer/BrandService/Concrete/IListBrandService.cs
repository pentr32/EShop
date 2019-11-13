using ServiceLayer.BrandService.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.Concrete
{
    public interface IListBrandService
    {
        IQueryable<BrandListDto> SortFilterPage(BrandListSortOptions option);
    }
}
