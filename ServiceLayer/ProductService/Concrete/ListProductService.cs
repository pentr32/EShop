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

        public ProductListDto UpdateProduct(ProductListDto updateProduct)
        {
            Product newUpdateProduct = new Product()
            {
                Model = updateProduct.Model,
                Price = updateProduct.Price,
                Color = updateProduct.Color,
                ImageName = updateProduct.ImageName,
                Description = updateProduct.Description,
                Year = updateProduct.Year,
                Storage = updateProduct.Storage,
                BrandID = updateProduct.BrandID,
                MaterialFrameTypeID = updateProduct.MaterialFrameTypeID
            };

            _context.Products.Update(newUpdateProduct);
            return updateProduct;
        }

        public void DeleteProduct(int ProductID)
        {
            var product = GetProductByID(ProductID);
            if (product != null) _context.Products.Remove(product);
        }

        public int Commit()
        {
            _context.SaveChanges();
            return 0;
        }
    }
}
