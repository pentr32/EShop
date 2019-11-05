using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public class ListProductService
    {
        private readonly EShopContext _context;
        public ListProductService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<ProductListDto> SortFilterPage(ProductListSortOptions option)
        {
            var query = _context.Products
                .AsNoTracking()
                .MapProductToDto()
                .OrderProductsBy(option.OrderByOptions)
                .FilterProductsBy(option.FilterBy, option.FilterValue);
            return query;
        }

        public void AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
        }

        public Product GetProductByID(int productID)
        {
            return _context.Products.Find(productID);
        }

        public void DeleteProduct(int ProductID)
        {
            var product = GetProductByID(ProductID);
            if (product != null) _context.Products.Remove(product);
        }
    }
}
