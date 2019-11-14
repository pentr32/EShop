using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CustomerService.CustomerDto;
using ServiceLayer.CustomerService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.Concrete
{
    public class ListCustomerService : IListCustomerService
    {
        private readonly EShopContext _context;
        public ListCustomerService(EShopContext context)
        {
            _context = context;
        }

        public IQueryable<CustomerListDto> SortFilterPage()
        {
            var query = _context.Customers
                .AsNoTracking()
                .MapCustomerToDto();
            return query;
        }
    }
}
