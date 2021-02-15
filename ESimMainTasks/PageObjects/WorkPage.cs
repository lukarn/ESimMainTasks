using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using System;
using System.Diagnostics;
using System.Threading;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace ESimMainTasks.PageObjects
{
    class WorkPage
    {
        private IWebDriver webDriver;

        public WorkPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

            PageFactory.InitElements(webDriver, this);
        }

        //@FindBy(css = "button#workButton")
        //private WebElement workButton;
        [FindsBy(How = How.CssSelector, Using = "button#workButton")]
        private IWebElement pracujButton { get; set; }

        public WorkPage SetPracujButton()
        {
            WaitAndClick(this.pracujButton);
            return this;
        }

        //        @FindBy(css = "#productionReportTable>tbody>tr>#productionDisplayInTable")
        //private WebElement workProductionResult;
        [FindsBy(How = How.CssSelector, Using = "#productionReportTable>tbody>tr>#productionDisplayInTable")]
        private IWebElement workProductionResult { get; set; }

        private string GetWorkProductionResult()
        {
            return this.workProductionResult.Text;
        }

        public bool WorkCheck()
        {
            try
            {
                Thread.Sleep(2000);
                
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                // or Trace.Listeners.Add(new ConsoleTraceListener());
                Trace.WriteLine("====Work results: " + GetWorkProductionResult());

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
