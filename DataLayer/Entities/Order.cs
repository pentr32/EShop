using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime EstimatedDate { get; set; }
        public string ShippingAddress { get; set; }

        public int CustomerID { get; set; }                     //FK
        public Customer Customer { get; set; }

        public int ShippingMethodID { get; set; }               //FK
        public ShippingMethod ShippingMethod { get; set; }

        public int PaymentMethodID { get; set; }                //FK
        public PaymentMethod PaymentMethod { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
