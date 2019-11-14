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

        [HttpPut("{BrandID}")]
        public async Task<IActionResult> PutTodoItem(int BrandID, BrandListDto Brand)
        {
            if (BrandID != Brand.BrandID)
            {
                return BadRequest();
            }

            _brandService.UpdateBrand(Brand);

            try
            {
                await _brandService.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_brandService.GetBrandByID(BrandID) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BrandListDto>> PostBrand(BrandListDto Brand)
        {
            _brandService.AddBrand(Brand);
            await _brandService.CommitAsync();

            return CreatedAtAction(nameof(GetBrandByBrandID), new { BrandID = Brand.BrandID }, Brand);
        }

        [HttpDelete("{BrandID}")]
        public async Task<ActionResult<BrandListDto>> DeleteProduct(int BrandID)
        {
            var brand = _brandService.GetBrandByID(BrandID);
            if (brand == null)
            {
                return NotFound();
            }

            _brandService.DeleteBrand(brand.BrandID);
            await _brandService.CommitAsync();

            return CreatedAtAction(nameof(GetBrandByBrandID), new { BrandID = brand.BrandID }, brand);
        }
    }
}