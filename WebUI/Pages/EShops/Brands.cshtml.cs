using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.BrandService.QueryObjects;

namespace WebUI.Pages.EShops
{
    public class BrandsModel : PageModel
    {
        public IEnumerable<BrandListDto> Brands { get; set; }

        private readonly IListBrandService _brandService;

        public BrandsModel(IListBrandService brandService)
        {
            _brandService = brandService;

        }
        public void OnGet()
        {
            BrandListSortOptions option = new BrandListSortOptions()
            {
                FilterBy = BrandFilterBy.NoFilter
            };

            Brands = _brandService.SortFilterPage(option).ToList();
        }
    }
}