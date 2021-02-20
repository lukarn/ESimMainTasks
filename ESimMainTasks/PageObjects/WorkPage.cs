using OpenQA.Selenium;

using System;
using System.Diagnostics;
using System.Threading;


namespace ESimMainTasks.PageObjects
{
    class WorkPage : Page
    {
        private IWebDriver WebDriver;

        public WorkPage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
            this.WebDriver = webDriver;
        }

        //@FindBy(css = "button#workButton")
        //private WebElement workButton;
        //[FindsBy(How = How.CssSelector, Using = "button#workButton")]
        //private IWebElement pracujButton { get; set; }
        private static By PracujButton => By.CssSelector("button#workButton");

        public WorkPage SetPracujButton()
        {
            //WaitAndClick(this.pracujButton);
            ClickElement(PracujButton);
            return this;
        }

        //        @FindBy(css = "#productionReportTable>tbody>tr>#productionDisplayInTable")
        //private WebElement workProductionResult;
        //[FindsBy(How = How.CssSelector, Using = "#productionReportTable>tbody>tr>#productionDisplayInTable")]
        //private IWebElement workProductionResult { get; set; }
        private static By WorkProductionResult => By.CssSelector("#productionReportTable>tbody>tr>#productionDisplayInTable");

        private string GetWorkProductionResult()
        {
            //return this.workProductionResult.Text;
            return GetElementText(WorkProductionResult);
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


        //private void WaitAndClick(IWebElement webElement)
        //{
        //    Thread.Sleep(1000);
        //    webElement.Click();
        //}












    }
}
