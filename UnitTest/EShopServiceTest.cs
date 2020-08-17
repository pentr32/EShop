using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Html5;
using System.Linq;
using System.Reflection;
using System.Globalization;
using DataLayer.Entities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace UnitTest
{
    #region Simple Data Test
    [TestClass]
    public class EShopServiceTest
    {
        //[TestMethod]
        //public void Add_New_Customer()
        //{
        //    var options = new DbContextOptionsBuilder<EShopContext>()
        //        .UseInMemoryDatabase(databaseName: "EShopDb_InMemory")
        //        .Options;
        //}

        IWebDriver _webDriver = new ChromeDriver();

        [TestMethod]
        public void OpenWebPage()
        {
            // Arrange
            var expected = "https://localhost:44364/";


            // Act
            _webDriver.Navigate().GoToUrl(@"https://localhost:44364/");

            string actual = _webDriver.Url;

            // Asserts
            Assert.AreEqual(expected, actual);
            _webDriver.Quit();
        }
    }
    #endregion Simple Data Test

    #region Med DataRow
    [TestClass]
    public class EShopServiceTestDataRow
    {
        IWebDriver _webDriver = new ChromeDriver();

        [DataTestMethod]
        [DataRow("FilterBy", 2, "SearchString", "Apple", @"https://localhost:44364/?OrderBy=0&FilterBy=2&SearchString=Apple")]
        [DataRow("FilterBy", 1, "SearchString", "6", @"https://localhost:44364/?OrderBy=0&FilterBy=1&SearchString=6")]
        public void SearchByBrandOnWebPage(string dropdownId, int optionValue, string textBoxId, string filterValue, string expected)
        {
            // Act
            _webDriver.Navigate().GoToUrl(@"https://localhost:44364/");

            _webDriver.FindElement(By.XPath("//select[@id='" + dropdownId + "']/option[@value='" + optionValue.ToString() + "']")).Click();
            _webDriver.FindElement(By.Id(textBoxId)).SendKeys(filterValue);

            _webDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string actual = _webDriver.Url;

            // Asserts
            Assert.AreEqual(expected, actual);
            _webDriver.Quit();
        }

        [DataTestMethod]
        [DataRow("/EShops/NewProduct", @"https://localhost:44364/")]
        public void CheckIfAddNewProductButtonExistOnWebPage(string newProductLink, string webPageLink)
        {
            // Act
            _webDriver.Navigate().GoToUrl(webPageLink);

            bool isButtonOnPage = _webDriver.FindElement(By.XPath("//a[@href='" + newProductLink + "']")).Enabled;

            // Asserts
            Assert.IsTrue(isButtonOnPage);
            _webDriver.Quit();
        }
    }
    #endregion Med DataRow

    #region Med DynamicData
    [TestClass]
    public class EShopServiceTestDynamicData
    {
        IWebDriver _webDriver = new ChromeDriver();

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CountMobilesOnWebPage(string className, int expected)
        {
            // Act
            _webDriver.Navigate().GoToUrl(@"https://localhost:44364/");

            int actual = _webDriver.FindElements(By.XPath("//div[@class='" + className + "']/div")).Count();

            // Asserts
            Assert.AreEqual(expected, actual);
            _webDriver.Quit();
        }
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "card-deck", 21 };
            yield return new object[] { "card-deck", 29 };
        }
    }
    #endregion Med DynamicData

    #region Med CustomData
    public class CustomDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] {"card-deck", 1, 20 };
            yield return new object[] {"card-deck", 3, 19 };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }

    [TestClass]
    public class EShopServiceTestCustomData
    {
        IWebDriver _webDriver = new ChromeDriver();

        [DataTestMethod]
        [CustomDataSource]
        public void DeleteProductOnWebPage(string className, int productId, int expected)
        {
            // Act
            _webDriver.Navigate().GoToUrl(@"https://localhost:44364/");

            _webDriver.FindElement(By.XPath("//a[@href='/EShops/Detail/" + productId + "']")).Click();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(4));
            IWebElement element = wait.Until(e => e.FindElement(By.XPath("//button[@type='submit']")));

            element.Click();

            int actual = _webDriver.FindElements(By.XPath("//div[@class='" + className + "']/div")).Count();

            // Asserts
            Assert.AreEqual(expected, actual);
            _webDriver.Quit();
        }
    }
    #endregion Med CustomData
}