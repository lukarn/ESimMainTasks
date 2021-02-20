using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ESimMainTasks.PageObjects;
using System.Threading;
using FluentAssertions;
using System.IO;
using System.Reflection;

namespace ESimMainTasks.Steps
{
    [Binding]
    public class ESimMainTasksSteps
    {
        IWebDriver WebDriver;
        IAppSettings AppSettings;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //webDriver = new ChromeDriver("C:\\selGrid");
        }

        //"Check work activity"
        [AfterScenario()]
        public void AfterScenario()
        {
            WebDriver.Close();
        }

        [Given(@"go to BasePage")]
        public void GivenGoToBasePage()
        {
            WebDriver.Url = "https://primera.e-sim.org/";
        }
        
        [Given(@"login to service")]
        public void GivenLogin()
        {
            var basePage = new BasePage(WebDriver, AppSettings);

            Thread.Sleep(3000);

            basePage.SetLoginButton()
                .SetLoginInput("sledzik")
                .SetPasswordInput("dieh@rd")
                .SetZalogujButton();



        }
        
        [When(@"click Train task button if it is present")]
        public void WhenClickTrainButtonIfItIsPresent()
        {
            var mainPage = new MainPage(WebDriver, AppSettings);
            try
            {
                mainPage.SetTrainTaskButtonn();
            }catch (Exception){
                mainPage.SetMenuMyPlacesButton()
                    .SetMenuTrainButton();

            }

        }

        [When(@"click Work task button if it is present")]
        public void WhenClickWorkTaskButtonIfItIsPresent()
        {
            var mainPage = new MainPage(WebDriver, AppSettings);
            try
            {
                mainPage.SetWorkTaskButton();
            }
            catch (Exception)
            {
                mainPage.SetMenuMyPlacesButton()
                    .SetMenuWorkButton();

            }
        }


        [When(@"click Trenuj button if it is present")]
        public void WhenClickTrainButton()
        {
            var trainPage = new TrainPage(WebDriver, AppSettings);
            try
            {
                trainPage.SetTrenujButton();
            }
            catch (Exception){
            }

        }

        [When(@"click Pracuj button if it is present")]
        public void WhenClickPracujButtonIfItIsPresent()
        {
            var workPage = new WorkPage(WebDriver, AppSettings);
            try
            {
                workPage.SetPracujButton();
            }
            catch (Exception){
            }
        }




        [Then(@"the timer to next train should be present")]
        public void ThenTheTimerToNextTrainShouldBePresent()
        {
            var trainPage = new TrainPage(WebDriver, AppSettings);
            trainPage.TrainCheck().Should().BeTrue();

        }

        [Then(@"check if work results are present")]
        public void ThenCheckIfWorkResultsArePresent()
        {
            var workPage = new WorkPage(WebDriver, AppSettings);
            workPage.WorkCheck().Should().BeTrue();
        }

    }
}
