using DataLayer.Entities;
using ServiceLayer.ProductService.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ProductService.Concrete
{
    public interface IListProductService
    {
        IQueryable<ProductListDto> SortFilterPage(ProductListSortOptions option);
        ProductListDto AddProduct(ProductListDto newProductDto);
        Product GetProductByID(int productID);
        ProductListDto UpdateProduct(ProductListDto updateProduct);
        void DeleteProduct(int ProductID);
        int Commit();
        Task CommitAsync();
    }
}
