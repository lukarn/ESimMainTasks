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

        [FindsBy(How = How.Id, Using = "login_section_btn")]
        private IWebElement loginButton { get; set; }

        public BasePage SetLoginButton()
        {
            WaitAndClick(this.loginButton);
            return this;
        }

        //[FindsBy(How = How.Id, Using = "registeredPlayerLogin")]
        //public IWebElement LoginInput { get; set; }
        [FindsBy(How = How.Id, Using = "registeredPlayerLogin")]
        private IWebElement loginInput { get; set; }

        public BasePage SetLoginInput(string text)
        {
            WaitAndClick(this.loginInput);
            this.loginInput.SendKeys(text);
            return this;
        }


        //[FindsBy(How = How.CssSelector, Using = "form > input[name='password']")]
        //public IWebElement PasswordInput { get; set; }
        //@FindBy(css = "form > input.required.valid[name='password']"),
        //@FindBy(css = "form#bestForm > input[name='password']")
        [FindsBy(How = How.CssSelector, Using = "form > input[name='password']")]
        private IWebElement passwordInput { get; set; }

        public BasePage SetPasswordInput(string text)
        {
            WaitAndClick(this.passwordInput);
            this.passwordInput.SendKeys(text);
            return this;
        }


        //[FindsBy(How = How.CssSelector, Using = "button.foundation-style.button.foundationButton[type='submit'][value='Login']")]
        //public IWebElement ZalogujButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button.foundation-style.button.foundationButton[type='submit'][value='Login']")]
        private IWebElement zalogujButton { get; set; }

        public void SetZalogujButton()
        {
            WaitAndClick(this.zalogujButton);
        }


        private void WaitAndClick(IWebElement webElement)
        {
            Thread.Sleep(1000);
            webElement.Click();
        }








    }
}
