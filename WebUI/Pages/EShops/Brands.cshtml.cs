using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;

namespace WebUI.Pages.EShops
{
    public class BrandsModel : PageModel
    {
        public IEnumerable<BrandListDto> Brands { get; set; }

        private readonly ListBrandService _brandService;

        public BrandsModel(ListBrandService brandService)
        {
            _brandService = brandService;

        }
        public void OnGet()
        {
            Brands = _brandService.SortFilterPage().ToList();
        }
    }
}