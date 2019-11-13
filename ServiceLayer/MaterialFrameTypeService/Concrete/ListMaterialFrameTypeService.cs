using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;
using ServiceLayer.MaterialFrameTypeService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.MaterialFrameTypeService.Concrete
{
    public class ListMaterialFrameTypeService : IListMaterialFrameTypeService
    {
        private readonly EShopContext _context;
        public ListMaterialFrameTypeService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<MaterialFrameTypeListDto> SortFilterPage()
        {
            var query = _context.MaterialFrameTypes
                .AsNoTracking()
                .MapMaterialFrameTypeToDto();
            return query;
        }
    }
}
