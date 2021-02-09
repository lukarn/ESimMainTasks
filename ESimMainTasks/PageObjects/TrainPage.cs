using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace ESimMainTasks.PageObjects
{
    class TrainPage
    {
        private IWebDriver webDriver;

        public TrainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

            PageFactory.InitElements(webDriver, this);
        }

        //    @FindBy(css = "button#trainButton")
        //private WebElement trainButton;
        [FindsBy(How = How.CssSelector, Using = "button#trainButton")]
        private IWebElement trenujButton { get; set; }

        public TrainPage SetTrenujButton()
        {
            WaitAndClick(this.trenujButton);
            return this;
        }

        //    @FindBy(css = ".timeCountdown.greenFont")
        //private WebElement timeCountdown;
        [FindsBy(How = How.CssSelector, Using = ".timeCountdown.greenFont")]
        private IWebElement timeCountdown { get; set; }

        private string GetTimeCountdown()
        {
            return this.timeCountdown.Text;
        }

        public bool TrainCheck()
        {
            try
            {
                Thread.Sleep(2000);
                
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                // or Trace.Listeners.Add(new ConsoleTraceListener());
                Trace.WriteLine("====To next train: " + GetTimeCountdown());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void WaitAndClick(IWebElement webElement)
        {
            Thread.Sleep(1000);
            webElement.Click();
        }










    }
}
