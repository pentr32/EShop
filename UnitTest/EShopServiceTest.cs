using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class EShopServiceTest
    {
        [TestMethod]
        public void Add_New_Customer()
        {
            var options = new DbContextOptionsBuilder<EShopContext>()
                .UseInMemoryDatabase(databaseName: "EShopDb_InMemory")
                .Options;

            //using(var context = new EShopContext(options))
            //{
            //    var productService = new ListProductService(context);
            //    var dropdownItems = ProductFilterDropdownService.GetFilterDropDownValues(ProductFilterBy.ByBrand).ToList();
            //}
        }
    }
}
