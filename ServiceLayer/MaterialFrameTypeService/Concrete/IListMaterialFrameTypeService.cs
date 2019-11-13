using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.MaterialFrameTypeService.Concrete
{
    public interface IListMaterialFrameTypeService
    {
        IQueryable<MaterialFrameTypeListDto> SortFilterPage();
    }
}
