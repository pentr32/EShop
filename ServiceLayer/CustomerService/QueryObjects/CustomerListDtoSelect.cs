using DataLayer.Entities;
using ServiceLayer.CustomerService.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.QueryObjects
{
    public static class CustomerListDtoSelect
    {
        public static IQueryable<CustomerListDto> MapCustomerToDto(this IQueryable<Customer> customers)
        {
            return customers.Select(c => new CustomerListDto
            {
                CustomerID = c.CustomerID,
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                NumberOfOrders = c.Orders.Count()
            });
        }
    }
}
