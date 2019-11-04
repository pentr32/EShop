using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class MaterialFrameType
    {
        public int MaterialFrameTypeID { get; set; }
        public string Type { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
