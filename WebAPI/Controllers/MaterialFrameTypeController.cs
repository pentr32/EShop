using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.MaterialFrameTypeService.Concrete;
using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;

namespace WebAPI.Controllers
{
    [Route("api/MaterialFrameTypes")]
    [ApiController]
    public class MaterialFrameTypeController : ControllerBase
    {
        private readonly IListMaterialFrameTypeService _materialFrameTypeService;

        public MaterialFrameTypeController(IListMaterialFrameTypeService materialFrameTypeService)
        {
            _materialFrameTypeService = materialFrameTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialFrameTypeListDto>>> GetBrands()
        {
            return await _materialFrameTypeService.SortFilterPage().ToListAsync();
        }
    }
}