using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BrandService.BrandDto;
using ServiceLayer.BrandService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BrandService.Concrete
{
    public class ListBrandService : IListBrandService
    {
        private readonly EShopContext _context;
        public ListBrandService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<BrandListDto> SortFilterPage(BrandListSortOptions option)
        {
            var query = _context.Brands
                .AsNoTracking()
                .MapBrandToDto()
                .FilterBrandBy(option.FilterBy, option.FilterValue);
            return query;
        }

        public BrandListDto AddBrand(BrandListDto newBrandDto)
        {
            Brand newBrand = new Brand()
            {
                Name = newBrandDto.Name,
                LogoName = newBrandDto.LogoName
            };

            _context.Brands.Add(newBrand);
            return newBrandDto;
        }

        public Brand GetBrandByID(int BrandID)
        {
            return _context.Brands.Find(BrandID);
        }

        public BrandListDto UpdateBrand(BrandListDto updateBrand)
        {
            var updatedBrand = _context.Brands
                .Where(b => b.BrandID == updateBrand.BrandID)
                .FirstOrDefault();

            updatedBrand.Name = updateBrand.Name;
            updatedBrand.LogoName = updateBrand.LogoName;

            _context.Brands.Update(updatedBrand);
            return updateBrand;
        }

        public void DeleteBrand(int BrandID)
        {
            var thisBrand = _context.Brands
                .Where(b => b.BrandID == BrandID)
                .FirstOrDefault();

            if (thisBrand != null) _context.Brands.Remove(thisBrand);
        }

        public int Commit()
        {
            _context.SaveChanges();
            return 0;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
