using OpenQA.Selenium;
using System;

namespace ESimMainTasks.PageObjects
{
    sealed class BasePage : Page
    {
        public BasePage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
        }

        public void GoToBasePage()
        {
            WebDriver.Navigate().GoToUrl(new Uri(Settings.BasePageUrl));
            WaitUntilPageIsDisplayed();
        }

        public override void WaitUntilPageIsDisplayed()
        {
            WaitForVisible(LoginButton);
        }

        private static By LoginButton => By.Id("login_section_btn");

        public BasePage SetLoginButton()
        {
            ClickElement(LoginButton);
            return this;
        }

        private static By LoginInput => By.Id("registeredPlayerLogin");

        public BasePage SetLoginInput(string text)
        {
            SendElementText(LoginInput, text);
            return this;
        }

        private static By PasswordInput => By.CssSelector("form > input[name='password']");

        public BasePage SetPasswordInput(string text)
        {
            SendElementText(PasswordInput, text);
            return this;
        }

        private static By ZalogujButton => By.CssSelector("button.foundation-style.button.foundationButton[type='submit'][value='Login']");


        public void SetZalogujButton()
        {
            ClickElement(ZalogujButton);
        }








    }
}
