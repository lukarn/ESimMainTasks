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
        IWebDriver webDriver;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //webDriver = new ChromeDriver("C:\\selGrid");
        }

        //"Check work activity"
        [AfterScenario()]
        public void AfterScenario()
        {
            webDriver.Close();
        }

        [Given(@"go to BasePage")]
        public void GivenGoToBasePage()
        {
            webDriver.Url = "https://primera.e-sim.org/";
        }
        
        [Given(@"login to service")]
        public void GivenLogin()
        {
            var basePage = new BasePage(webDriver);

            Thread.Sleep(3000);

            basePage.SetLoginButton()
                .SetLoginInput("sledzik")
                .SetPasswordInput("dieh@rd")
                .SetZalogujButton();



        }
        
        [When(@"click Train task button if it is present")]
        public void WhenClickTrainButtonIfItIsPresent()
        {
            var mainPage = new MainPage(webDriver);
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
            var mainPage = new MainPage(webDriver);
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
            var trainPage = new TrainPage(webDriver);
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
            var workPage = new WorkPage(webDriver);
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
            var trainPage = new TrainPage(webDriver);
            trainPage.TrainCheck().Should().BeTrue();

        }

        [Then(@"check if work results are present")]
        public void ThenCheckIfWorkResultsArePresent()
        {
            var workPage = new WorkPage(webDriver);
            workPage.WorkCheck().Should().BeTrue();
        }

    }
}
