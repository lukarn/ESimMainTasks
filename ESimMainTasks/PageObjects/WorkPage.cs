using OpenQA.Selenium;

using System;
using System.Diagnostics;
using System.Threading;


namespace ESimMainTasks.PageObjects
{
    sealed class WorkPage : Page
    {
        public WorkPage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
        }

        public override void WaitUntilPageIsDisplayed()
        {
            WaitForVisible(PracujButton);
        }

        private static By PracujButton => By.CssSelector("button#workButton");

        public WorkPage SetPracujButton()
        {
            ClickElement(PracujButton);
            return this;
        }

        private static By WorkProductionResult => By.CssSelector("#productionReportTable>tbody>tr>#productionDisplayInTable");

        private string GetWorkProductionResult()
        {
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




    }
}
