using OpenQA.Selenium;
using System.Threading;

namespace ESimMainTasks.PageObjects
{
    class BasePage : Page
    {
        private IWebDriver WebDriver;

        public BasePage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
            this.WebDriver = webDriver;
        }

        private static By LoginButton => By.Id("login_section_btn");

        public BasePage SetLoginButton()
        {
            //WaitAndClick(LoginButton);
            ClickElement(LoginButton);
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
            //WaitAndClick(ZalogujButton);
            ClickElement(ZalogujButton);
        }


        //private void WaitAndClick(By bySelector)
        //{
        //    Thread.Sleep(1000);
        //    WebDriver.FindElement(bySelector).Click();
        //    //webElement.Click();
        //}

        private void WaitAndSendText(By bySelector, string text)
        {
            Thread.Sleep(1000);
            WebDriver.FindElement(bySelector).SendKeys(text);
        }








    }
}
