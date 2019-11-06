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

        public ProductListDto AddProduct(ProductListDto newProductDto)
        {
            Product newProduct = new Product()
            {
                Model = newProductDto.Model,
                Price = newProductDto.Price,
                Color = newProductDto.Color,
                ImageName = newProductDto.ImageName,
                Description = newProductDto.Description,
                Year = newProductDto.Year,
                Storage = newProductDto.Storage,
                BrandID = newProductDto.BrandID,
                MaterialFrameTypeID = newProductDto.MaterialFrameTypeID
            };
            _context.Products.Add(newProduct);
            return newProductDto;
        }

        public Product GetProductByID(int productID)
        {
            return _context.Products.Find(productID);
        }

        public ProductListDto UpdateProduct(ProductListDto updateProduct)
        {
            var updatedProduct = _context.Products
                .Where(p => p.ProductID == updateProduct.ProductID)
                .FirstOrDefault();

            updatedProduct.Model = updateProduct.Model;
            updatedProduct.Price = updateProduct.Price;
            updatedProduct.Color = updateProduct.Color;
            updatedProduct.ImageName = updateProduct.ImageName;
            updatedProduct.Description = updateProduct.Description;
            updatedProduct.Year = updateProduct.Year;
            updatedProduct.Storage = updateProduct.Storage;
            updatedProduct.BrandID = updateProduct.BrandID;
            updatedProduct.MaterialFrameTypeID = updateProduct.MaterialFrameTypeID;

            _context.Products.Update(updatedProduct);
            return updateProduct;
        }

        public void DeleteProduct(int ProductID)
        {
            var thisProduct = _context.Products
                .Where(p => p.ProductID == ProductID)
                .FirstOrDefault();

            if (thisProduct != null) _context.Products.Remove(thisProduct);
        }

        public int Commit()
        {
            _context.SaveChanges();
            return 0;
        }
    }
}
