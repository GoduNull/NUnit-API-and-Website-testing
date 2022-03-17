using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace BookingPageTests
{
    public class AllTests
    {
        private IWebDriver _driver;

        private readonly By _currencyButton = By.XPath("//button[@data-modal-aria-label='¬˚·ÂËÚÂ ‚‡Î˛ÚÛ']");
        private readonly By _select—urrency = By.XPath("//div[@class='bui-traveller-header__currency']");
        private readonly By _actualCurrency = By.XPath("//button[@data-modal-aria-label='¬˚·ÂËÚÂ ‚‡Î˛ÚÛ']//span[@aria-hidden='true']");

        private readonly By _languageButton = By.XPath("//button[@data-tooltip-text='¬˚·ÂËÚÂ ˇÁ˚Í']");
        private readonly By _selectLanguage = By.XPath("//div[@lang]");
        private readonly By _actualLanguage = By.XPath("//html[@lang]");

        private readonly By _airTicketsButton = By.XPath("//a[@data-decider-header='flights']");

        private readonly By _singInButton = By.XPath("//a[@data-et-click='customGoal:YTBUIHOdBOcaGPaVHXT:2']");
        private readonly By _loginInput = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@type='submit']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _enterButton = By.XPath("//button[@type='submit']");

        private readonly By _locationButton = By.XPath("//input[@type='search']");
        private readonly By _dateButton = By.XPath("//span[@class='sb-date-field__icon sb-date-field__icon-btn bk-svg-wrapper calendar-restructure-sb']");
        private readonly By _selectDate = By.XPath("//td[@data-date]");
        private readonly By _selectNumberPassengersButton = By.XPath("//label[@id='xp__guests__toggle']");
        private readonly By _add—hildButton = By.XPath("//button[@class='bui-button bui-button--secondary bui-stepper__add-button '] [@aria-describedby='group_children_desc' ]");
        private readonly By _checkFilterButton = By.XPath("//button[@data-sb-id='main']");
        private readonly By _selectAgeChild = By.XPath("//select[@name='age']//option[@value='1']");

        private const string _airTicketsUrl = "https://booking.kayak.com/";
        private const string _searchUrl = "https://www.booking.com/searchresults.ru";


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
            var ss = "eur";
            var sinIn = _driver.FindElement(_currencyButton);
            sinIn.Click();

            Thread.Sleep(400);
            var choice = _driver.FindElements(_select—urrency).First(x => x.Text == ss.ToUpper());
            choice.Click();

            Thread.Sleep(400);
            var actualCurrency = _driver.FindElement(_actualCurrency).Text;

            Assert.AreEqual(ss.ToUpper(), actualCurrency);
        }
        [Test]
        public void LanguageTest()
        {
            var ss = "fr";
            var sinIn = _driver.FindElement(_languageButton);
            sinIn.Click();

            Thread.Sleep(400);
            var choice = _driver.FindElements(_selectLanguage).First(x => x.GetAttribute("lang") == ss);
            choice.Click();

            Thread.Sleep(400);
            var actualLanguage = _driver.FindElement(_actualLanguage).GetAttribute("lang");

            Assert.AreEqual(ss, actualLanguage);
        }
        [Test]
        public void UrlTest()
        {
            var airTickets = _driver.FindElement(_airTicketsButton);
            airTickets.Click();

            Thread.Sleep(2000);
            var url = _driver.Url;
            Assert.IsTrue(url.StartsWith(_airTicketsUrl));
        }
        [Test]
        public void AuthenticationTest()
        {
            var singIn = _driver.FindElement(_singInButton);
            singIn.Click();

            Thread.Sleep(400);
            var loginInput = _driver.FindElement(_loginInput);
            loginInput.SendKeys("2184236@mtp.by");

            Thread.Sleep(400);
            var continueButton = _driver.FindElement(_continueButton);
            continueButton.Click();

            Thread.Sleep(400);
            var passwordInput = _driver.FindElement(_passwordInput);
            passwordInput.SendKeys("2zz_!_NSgL8u?$5");

            Thread.Sleep(400);
            var enterButton = _driver.FindElement(_enterButton);
            enterButton.Click();
        }
        [Test]
        public void FilterTest()
        {
            var cc = DateTime.Now;
            var departureDate = cc.AddDays(7);
            var arrivalDate = departureDate.AddDays(2);
            var locationButton = _driver.FindElement(_locationButton);
            locationButton.SendKeys("ÃËÌÒÍ");

            Thread.Sleep(1000);
            var dateButton = _driver.FindElement(_dateButton);
            dateButton.Click();

            Thread.Sleep(1000);
            var selectDepartureDate = _driver.FindElements(_selectDate).First(x => 
            x.GetAttribute("data-date") == departureDate.ToString("yyyy-MM-dd"));
            selectDepartureDate.Click();

            var selectArrivalDate = _driver.FindElements(_selectDate).First(x =>
            x.GetAttribute("data-date") == arrivalDate.ToString("yyyy-MM-dd"));
            selectArrivalDate.Click();

            var selectPassengers = _driver.FindElement(_selectNumberPassengersButton);
            selectPassengers.Click();

            var addChildButton = _driver.FindElement(_add—hildButton);
            addChildButton.Click();


            var selectAge = _driver.FindElement(_selectAgeChild);
            selectAge.Click();

            var checkFilter = _driver.FindElement(_checkFilterButton);
            checkFilter.Click();

            Thread.Sleep(1000);
            var url = _driver.Url;
            Assert.IsTrue(url.StartsWith(_searchUrl));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}