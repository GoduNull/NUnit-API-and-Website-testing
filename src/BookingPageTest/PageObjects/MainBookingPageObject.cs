using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BookingPageTest.PageObjects
{
    internal class MainBookingPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _currencyButton = By.XPath("//button[@data-modal-aria-label='Выберите валюту']");
        private readonly By _selectСurrency = By.XPath("//div[@class='bui-traveller-header__currency']");
        private readonly By _actualCurrency = By.XPath("//button[@data-modal-aria-label='Выберите валюту']//span[@aria-hidden='true']");

        private readonly By _languageButton = By.XPath("//button[@data-tooltip-text='Выберите язык']");
        private readonly By _selectLanguage = By.XPath("//div[@lang]");
        private readonly By _actualLanguage = By.XPath("//html[@lang]");

        private readonly By _airTicketsButton = By.XPath("//a[@data-decider-header='flights']");

        private readonly By _singInButton = By.XPath("//a[@data-et-click='customGoal:YTBUIHOdBOcaGPaVHXT:2']");

        private readonly By _locationButton = By.XPath("//input[@type='search']");
        private readonly By _dateButton = By.XPath("//span[@class='sb-date-field__icon sb-date-field__icon-btn bk-svg-wrapper calendar-restructure-sb']");
        private readonly By _selectDate = By.XPath("//td[@data-date]");
        private readonly By _selectNumberPassengersButton = By.XPath("//label[@id='xp__guests__toggle']");
        private readonly By _addСhildButton = By.XPath("//button[@class='bui-button bui-button--secondary bui-stepper__add-button '] [@aria-describedby='group_children_desc' ]");
        private readonly By _checkFilterButton = By.XPath("//button[@data-sb-id='main']");
        private readonly By _selectAgeChild = By.XPath("//select[@name='age']//option[@value='1']");

        private const string _airTicketsUrl = "https://booking.kayak.com/";
        private const string _searchUrl = "https://www.booking.com/searchresults.ru";

        public MainBookingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string Currency(string currenсy)
        {
            var sinIn = _webDriver.FindElement(_currencyButton);
            sinIn.Click();

            Thread.Sleep(400);
            var choice = _webDriver.FindElements(_selectСurrency).First(x => x.Text == currenсy.ToUpper());
            choice.Click();

            Thread.Sleep(400);
            return _webDriver.FindElement(_actualCurrency).Text;
        }
        public string Language(string language)
        {
            var sinIn = _webDriver.FindElement(_languageButton);
            sinIn.Click();

            Thread.Sleep(400);
            var choice = _webDriver.FindElements(_selectLanguage).First(x => x.GetAttribute("lang") == language);
            choice.Click();

            Thread.Sleep(400);
            return _webDriver.FindElement(_actualLanguage).GetAttribute("lang");
        }
        public bool AirTickets()
        {
            var airTickets = _webDriver.FindElement(_airTicketsButton);
            airTickets.Click();
            Thread.Sleep(2000);
            var url = _webDriver.Url;
            return url.StartsWith(_airTicketsUrl);
        }

        public AuthorizationBookingPageObject Authorization()
        {
            var singIn = _webDriver.FindElement(_singInButton);
            singIn.Click();
            return new AuthorizationBookingPageObject(_webDriver);
        }
        public bool Filter(string location, DateTime date)
        {
            var departureDate = date.AddDays(7);
            var arrivalDate = departureDate.AddDays(2);
            var locationButton = _webDriver.FindElement(_locationButton);
            locationButton.SendKeys(location);

            Thread.Sleep(1000);
            var dateButton = _webDriver.FindElement(_dateButton);
            dateButton.Click();

            Thread.Sleep(1000);
            var selectDepartureDate = _webDriver.FindElements(_selectDate).First(x =>
            x.GetAttribute("data-date") == departureDate.ToString("yyyy-MM-dd"));
            selectDepartureDate.Click();

            var selectArrivalDate = _webDriver.FindElements(_selectDate).First(x =>
            x.GetAttribute("data-date") == arrivalDate.ToString("yyyy-MM-dd"));
            selectArrivalDate.Click();

            var selectPassengers = _webDriver.FindElement(_selectNumberPassengersButton);
            selectPassengers.Click();

            var addChildButton = _webDriver.FindElement(_addСhildButton);
            addChildButton.Click();


            var selectAge = _webDriver.FindElement(_selectAgeChild);
            selectAge.Click();

            var checkFilter = _webDriver.FindElement(_checkFilterButton);
            checkFilter.Click();

            Thread.Sleep(1000);
            var url = _webDriver.Url;
            return url.StartsWith(_searchUrl);
        }
    }
}
