using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public DateTime? Year { get; set; }
        public double Storage { get; set; }

        public int? BrandID { get; set; }                                 //FK
        public Brand Brand { get; set; }

        public int? MaterialFrameTypeID { get; set; }                     //FK
        public MaterialFrameType MaterialFrameType { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
