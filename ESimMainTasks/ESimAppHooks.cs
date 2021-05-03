using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace ESimMainTasks
{
    sealed class ESimAppHooks
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
            FirefoxOptions options = new FirefoxOptions();
            //options.AddArguments("--headless");

            return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);

        }

        private static IWebDriver LaunchChrome()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
        }

    }
}
