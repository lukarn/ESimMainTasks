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

        BasePage basePage;
        MainPage mainPage;
        TrainPage trainPage;
        WorkPage workPage;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //webDriver = new ChromeDriver("C:\\selGrid");

            basePage = new BasePage(WebDriver, AppSettings);
            mainPage = new MainPage(WebDriver, AppSettings);
            trainPage = new TrainPage(WebDriver, AppSettings);
            workPage = new WorkPage(WebDriver, AppSettings);
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

            basePage.SetLoginButton()
                .SetLoginInput("sledzik")
                .SetPasswordInput("dieh@rd")
                .SetZalogujButton();



        }
        
        [When(@"click Train task button if it is present")]
        public void WhenClickTrainButtonIfItIsPresent()
        {
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
            trainPage.TrainCheck().Should().BeTrue();

        }

        [Then(@"check if work results are present")]
        public void ThenCheckIfWorkResultsArePresent()
        {
            workPage.WorkCheck().Should().BeTrue();
        }

    }
}
