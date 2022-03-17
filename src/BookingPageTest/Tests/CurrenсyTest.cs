using BookingPageTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingPageTest
{
    public class Curren�yTest
    {
        private IWebDriver _driver;
        private string _curren�y= "eur";

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
            Assert.AreEqual(_curren�y.ToUpper(), mainPage.Currency(_curren�y));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}