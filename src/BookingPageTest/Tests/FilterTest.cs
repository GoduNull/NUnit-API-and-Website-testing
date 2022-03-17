using BookingPageTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace BookingPageTests
{
    public class FilterTest
    {
        private IWebDriver _driver;
        private DateTime dateTime = DateTime.Now;
        private string location = "Минск";
        
        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.booking.com");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            var mainPage = new MainBookingPageObject(_driver);
            Assert.IsTrue(mainPage.Filter(location,dateTime));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}