using BookingPageTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingPageTest
{
    public class LanguageTest
    {
        private IWebDriver _driver;
        private string _language = "fr";

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
            Assert.AreEqual(_language, mainPage.Language(_language));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}