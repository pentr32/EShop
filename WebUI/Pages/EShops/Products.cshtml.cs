using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebUI.Pages.EShops
{
    public class ProductsModel : PageModel
    {
        public IEnumerable<ProductListDto> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public OrderByOptions OrderBy { get; set; }
        [BindProperty(SupportsGet = true)]
        public ProductFilterBy FilterBy { get; set; }
        public string SearchString { get; set; }

        private readonly IListProductService _productService;

        public ProductsModel(IListProductService productService)
        {
            _productService = productService;
        }

        public void OnGet(string SearchString)
        {
            ProductListSortOptions Option = new ProductListSortOptions()
            {
                OrderByOptions = OrderBy,
                FilterBy = FilterBy,
                FilterValue = SearchString
            };

            Products = _productService.SortFilterPage(Option).ToList();
        }
    }
}