using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ShippingMethod
    {
        public int ShippingMethodID { get; set; }
        public string Transporter { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
