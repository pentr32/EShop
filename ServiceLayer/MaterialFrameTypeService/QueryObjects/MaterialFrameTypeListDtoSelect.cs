using DataLayer.Entities;
using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.MaterialFrameTypeService.QueryObjects
{
    public static class MaterialFrameTypeListDtoSelect
    {
        public static IQueryable<MaterialFrameTypeListDto> MapMaterialFrameTypeToDto(this IQueryable<MaterialFrameType> types)
        {
            return types.Select(m => new MaterialFrameTypeListDto
            {
                MaterialFrameTypeID = m.MaterialFrameTypeID,
                Type = m.Type
            });
        }
    }
}
