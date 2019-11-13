using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebUI.Pages.EShops
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public ProductListDto Product { get; set; }

        private readonly IListProductService _productService;

        public DetailModel(IListProductService productService)
        {
            _productService = productService;
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

            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Product.ProductID > 0) _productService.DeleteProduct(Product.ProductID);

            _productService.Commit();
            return RedirectToPage("/EShops/Products");
        }
    }
}