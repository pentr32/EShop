using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CustomerService.CustomerDto
{
    public class CustomerListDto
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int NumberOfOrders { get; set; }
    }
}
