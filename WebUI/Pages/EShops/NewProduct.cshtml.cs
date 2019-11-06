using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;
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
        private readonly ListProductService _productService;
        private readonly ListBrandService _brandService;
        private readonly ListMaterialFrameTypeService _materialFrameTypeService;
        public NewProduct(ListProductService productService, ListBrandService brandService, ListMaterialFrameTypeService materialFrameTypeService)
        {
            _productService = productService;
            _brandService = brandService;
            _materialFrameTypeService = materialFrameTypeService;
        }

        public void OnGet()
        {
            Brands = _brandService.SortFilterPage().ToList();
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