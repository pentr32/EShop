using DataLayer.Entities;
using ServiceLayer.BrandService.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BrandService.Concrete
{
    public interface IListBrandService
    {
        IQueryable<BrandListDto> SortFilterPage(BrandListSortOptions option);
        BrandListDto AddBrand(BrandListDto newBrandDto);
        Brand GetBrandByID(int BrandID);
        BrandListDto UpdateBrand(BrandListDto updateBrand);
        void DeleteBrand(int BrandID);
        int Commit();
        Task CommitAsync();
    }
}
