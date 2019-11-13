using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IListProductService _productService;

        public ProductViewComponent(IListProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            ProductListSortOptions Option = new ProductListSortOptions();
            var products = _productService.SortFilterPage(Option).ToList().Count();
            return View(products);
        }
    }
}
