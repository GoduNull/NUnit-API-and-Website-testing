using BookingPageTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingPageTests
{
    public class AirTicketsTest
    {
        private IWebDriver _driver;

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
            Assert.IsTrue(mainPage.AirTickets());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}