﻿using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;

namespace ESimMainTasks.PageObjects
{
    sealed class TrainPage : Page
    {
        public TrainPage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
        }

        public override void WaitUntilPageIsDisplayed()
        {
            WaitForVisible(TrenujButton);
        }

        private static By TrenujButton => By.CssSelector("button#trainButton");

        public TrainPage SetTrenujButton()
        {
            ClickElement(TrenujButton);
            return this;
        }

        private static By TimeCountdown => By.CssSelector(".timeCountdown.greenFont");

        private string GetTimeCountdown()
        {
            return GetElementText(TimeCountdown);
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




    }
}
