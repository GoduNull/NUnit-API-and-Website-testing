using BookingPageTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingPageTest
{
    public class AuthenticationTest
    {
        private IWebDriver _driver;
        private const string login = "2184236@mtp.by";
        private const string password = "2zz_!_NSgL8u?$5";

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
            mainPage.Authorization().Login(login, password);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}