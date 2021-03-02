using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESimMainTasks.PageObjects
{
    public abstract class Page
    {
        protected IAppSettings Settings { get; }

        protected IWebDriver WebDriver { get; }

        private const int DefaultTimeout = 10;

        public abstract void WaitUntilPageIsDisplayed();

        protected Page(IWebDriver webDriver, IAppSettings settings)
        {
            Settings = settings;
            WebDriver = webDriver;
        }

        protected void ClickElement(By bySelector)
        {
            WaitForClickable(bySelector, DefaultTimeout);
            GetElement(bySelector).Click();
        }

        protected string GetElementText(By bySelector)
        {
            return GetElement(bySelector).Text;
        }

        protected void SendElementText(By bySelector, string text)
        {
            WaitForClickable(bySelector, DefaultTimeout);
            GetElement(bySelector).SendKeys(text);
        }

        protected void WaitForClickable(By bySelector, int timeout)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bySelector));
        }

        protected IWebElement GetElement(By bySelector)
        {
            return GetElement(bySelector, DefaultTimeout);
        }

        private IWebElement GetElement(By bySelector, int defaultTimeout)
        {
            WaitForVisible(bySelector, defaultTimeout);
            return WebDriver.FindElement(bySelector);
        }

        protected void WaitForVisible(By bySelector)
        {
            WaitForVisible(bySelector, DefaultTimeout);
        }

        private void WaitForVisible(By bySelector, int timeout)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySelector));
        }



    }
}
