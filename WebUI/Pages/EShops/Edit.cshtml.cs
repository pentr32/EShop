using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.BrandService.QueryObjects;
using ServiceLayer.MaterialFrameTypeService.Concrete;
using ServiceLayer.MaterialFrameTypeService.MaterialFrameTypeDto;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebUI.Pages.EShops
{
    public class EditModel : PageModel
    {
        public IEnumerable<BrandListDto> Brands { get; set; }
        public IEnumerable<MaterialFrameTypeListDto> MaterialFrameTypes { get; set; }

        [BindProperty]
        public ProductListDto Product { get; set; }

        private readonly ListProductService _productService;
        private readonly ListBrandService _brandService;
        private readonly ListMaterialFrameTypeService _materialFrameTypeService;

        public EditModel(ListProductService productService, ListBrandService brandService, ListMaterialFrameTypeService materialFrameTypeService)
        {
            _productService = productService;
            _brandService = brandService;
            _materialFrameTypeService = materialFrameTypeService;
        }

        public IActionResult OnGet(int ProductID)
        {
            ProductListSortOptions Option = new ProductListSortOptions()
            {
                OrderByOptions = OrderByOptions.Brand,
                FilterBy = ProductFilterBy.ByProductID,
                FilterValue = ProductID.ToString()
            };

            Product = _productService.SortFilterPage(Option).First();
            Brands = _brandService.SortFilterPage().ToList();
            MaterialFrameTypes = _materialFrameTypeService.SortFilterPage().ToList();

            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(Product.ProductID > 0)
            {
                _productService.UpdateProduct(Product);
            }
            _productService.Commit();
            return RedirectToPage("/EShops/Detail", new { productID = Product.ProductID });
        }
    }
}