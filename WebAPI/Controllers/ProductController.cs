﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.ProductDto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IListProductService _productService;

        public ProductController(IListProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProducts()
        {
            ProductListSortOptions Option = new ProductListSortOptions();
            return await _productService.SortFilterPage(Option).ToListAsync();
        }

        [HttpGet("{OrderBy}")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProductByOrder(OrderByOptions OrderBy)
        {
            ProductListSortOptions Option = new ProductListSortOptions()
            {
                OrderByOptions = OrderBy    //Brand, Color, HighPrice, LowPrice, MaterialFrameType, Model, SimpleOrder, Storage, Year
            };

            return await _productService.SortFilterPage(Option).ToListAsync();
        }

        [HttpGet("{OrderBy}/{FilterBy}")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProductByOrderAndFilterBy(OrderByOptions OrderBy, ProductFilterBy FilterBy)
        {
            ProductListSortOptions Option = new ProductListSortOptions()
            {
                OrderByOptions = OrderBy,    //Brand, Color, HighPrice, LowPrice, MaterialFrameType, Model, SimpleOrder, Storage, Year
                FilterBy = FilterBy          //ByBrand, ByMaterialFrameType, NoFilter
            };

            return await _productService.SortFilterPage(Option).ToListAsync();
        }

        [HttpGet("{OrderBy}/{FilterBy}/{FilterValue}")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProductByFullCustom(OrderByOptions OrderBy, ProductFilterBy FilterBy, string FilterValue)
        {
            ProductListSortOptions Option = new ProductListSortOptions()
            {
                OrderByOptions = OrderBy,    //Brand, Color, HighPrice, LowPrice, MaterialFrameType, Model, SimpleOrder, Storage, Year
                FilterBy = FilterBy,         //ByBrand, ByMaterialFrameType, NoFilter
                FilterValue = FilterValue    //Input Value
            };

            return await _productService.SortFilterPage(Option).ToListAsync();
        }

        [HttpPut("{ProductID}")]
        public async Task<IActionResult> PutTodoItem(int ProductID, ProductListDto Product)
        {
            if (ProductID != Product.ProductID)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(Product);

            try
            {
                await _productService.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_productService.GetProductByID(ProductID) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductListDto>> PostProduct(ProductListDto Product)
        {
            _productService.AddProduct(Product);
            await _productService.CommitAsync();

            return CreatedAtAction(nameof(GetProductByFullCustom), new { ProductID = Product.ProductID }, Product);
        }

        [HttpDelete("{ProductID}")]
        public async Task<ActionResult<ProductListDto>> DeleteProduct(int ProductID)
        {
            var product = _productService.GetProductByID(ProductID);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(product.ProductID);
            await _productService.CommitAsync();

            return CreatedAtAction(nameof(GetProductByFullCustom), new { ProductID = product.ProductID }, product);
        }
    }
}