using ServiceLayer.CustomerService.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.Concrete
{
    public interface IListCustomerService
    {
        IQueryable<CustomerListDto> SortFilterPage();
    }
}
