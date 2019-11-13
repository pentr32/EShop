using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public interface IProductFilterDropdownService
    {
        IEnumerable<DropdownTuple> GetFilterDropDownValues(ProductFilterBy filterBy);
    }
}
