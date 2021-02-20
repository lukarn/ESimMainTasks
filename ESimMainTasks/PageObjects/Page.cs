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

        protected void WaitForClickable(By bySelector, int timeout)
        {
            //new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout)).Until(SeleniumExtras.ExpectedConditions.ElementToBeClickable(bySelector));
            //WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bySelector));

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

        private void WaitForVisible(By bySelector, int timeout)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySelector));
        }

        //private void WaitAndClick(By bySelector)
        //{
        //    Thread.Sleep(1000);
        //    webDriver.FindElement(bySelector).Click();
        //    //webElement.Click();
        //}

        //private void WaitAndSendText(By bySelector, string text)
        //{
        //    Thread.Sleep(1000);
        //    webDriver.FindElement(bySelector).SendKeys(text);
        //}

    }
}
