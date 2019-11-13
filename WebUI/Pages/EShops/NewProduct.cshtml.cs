using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.BrandService.QueryObjects;
using ServiceLayer.MaterialFrameTypeService.Concrete;
using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;

namespace WebUI.Pages.EShops
{
    public class NewProduct : PageModel
    {
        public IEnumerable<BrandListDto> Brands { get; set; }
        public IEnumerable<MaterialFrameTypeListDto> MaterialFrameTypes { get; set; }

        [BindProperty]
        public ProductListDto Product { get; set; }
        private readonly IListProductService _productService;
        private readonly IListBrandService _brandService;
        private readonly IListMaterialFrameTypeService _materialFrameTypeService;
        public NewProduct(IListProductService productService, IListBrandService brandService, IListMaterialFrameTypeService materialFrameTypeService)
        {
            _productService = productService;
            _brandService = brandService;
            _materialFrameTypeService = materialFrameTypeService;
        }

        public void OnGet()
        {
            BrandListSortOptions option = new BrandListSortOptions()
            {
                FilterBy = BrandFilterBy.NoFilter
            };

            Brands = _brandService.SortFilterPage(option).ToList();
            MaterialFrameTypes = _materialFrameTypeService.SortFilterPage().ToList();
        }

        public IActionResult OnPost()
        {
            _productService.AddProduct(Product);
            _productService.Commit();
            return RedirectToPage("/EShops/Products");
        }
    }
}