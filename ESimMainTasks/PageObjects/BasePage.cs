using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace ESimMainTasks.PageObjects
{
    class BasePage
    {
        private IWebDriver webDriver;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

            PageFactory.InitElements(webDriver, this);
        }

        private static By LoginButton => By.Id("login_section_btn");

        public BasePage SetLoginButton()
        {
            WaitAndClick(LoginButton);
            return this;
        }

        private static By LoginInput => By.Id("registeredPlayerLogin");

        public BasePage SetLoginInput(string text)
        {
            WaitAndSendText(LoginInput, text);
            return this;
        }

        private static By PasswordInput => By.CssSelector("form > input[name='password']");

        public BasePage SetPasswordInput(string text)
        {
            WaitAndSendText(PasswordInput, text);
            return this;
        }

        private static By ZalogujButton => By.CssSelector("button.foundation-style.button.foundationButton[type='submit'][value='Login']");


        public void SetZalogujButton()
        {
            WaitAndClick(ZalogujButton);
        }


        private void WaitAndClick(By bySelector)
        {
            Thread.Sleep(1000);
            webDriver.FindElement(bySelector).Click();
            //webElement.Click();
        }

        private void WaitAndSendText(By bySelector, string text)
        {
            Thread.Sleep(1000);
            webDriver.FindElement(bySelector).SendKeys(text);
        }








    }
}
