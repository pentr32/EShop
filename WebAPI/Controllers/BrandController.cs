using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.BrandService.QueryObjects;

namespace WebAPI.Controllers
{
    [Route("api/Brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IListBrandService _brandService;

        public BrandController(IListBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandListDto>>> GetBrands()
        {
            BrandListSortOptions Option = new BrandListSortOptions();
            return await _brandService.SortFilterPage(Option).ToListAsync();
        }

        [HttpGet("{FilterBy}/{FilterValue}")]
        public async Task<ActionResult<IEnumerable<BrandListDto>>> GetBrandByBrandID(BrandFilterBy FilterBy, string FilterValue)
        {
            BrandListSortOptions Option = new BrandListSortOptions()
            {
                FilterBy = FilterBy, //NoFilter, ByBrandID, ByBrandName
                FilterValue = FilterValue
            };

            return await _brandService.SortFilterPage(Option).ToListAsync();
        }
    }
}