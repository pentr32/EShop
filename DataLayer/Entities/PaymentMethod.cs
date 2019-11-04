using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string Payment { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
