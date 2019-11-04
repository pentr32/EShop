using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
