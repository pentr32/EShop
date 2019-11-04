using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
