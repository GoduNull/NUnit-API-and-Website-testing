using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookingPageTests.PageObjects
{
    class AuthorizationBookingPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginInput = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@type='submit']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _enterButton = By.XPath("//button[@type='submit']");
        public AuthorizationBookingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainBookingPageObject Login(string login, string password)
        {
            Thread.Sleep(400);
            var loginInput = _webDriver.FindElement(_loginInput);
            loginInput.SendKeys("2184236@mtp.by");

            Thread.Sleep(400);
            var continueButton = _webDriver.FindElement(_continueButton);
            continueButton.Click();

            Thread.Sleep(400);
            var passwordInput = _webDriver.FindElement(_passwordInput);
            passwordInput.SendKeys("2zz_!_NSgL8u?$5");

            Thread.Sleep(400);
            var enterButton = _webDriver.FindElement(_enterButton);
            enterButton.Click();
            return new MainBookingPageObject(_webDriver);
        }
    }
}
