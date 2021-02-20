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
