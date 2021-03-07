using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace ESimMainTasks
{
    class ESimAppHooks
    {
        public static IWebDriver GetWebDriver(string driverToLaunch)
        {
            return driverToLaunch switch
            {
                "chrome" => LaunchChrome(),
                "firefox" => LaunchFirefox(),
                _ => throw new ConfigurationErrorsException("Browser not supported."),
            };
        }

        private static IWebDriver LaunchFirefox()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

        }

        private static IWebDriver LaunchChrome()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
        }

    }
}
