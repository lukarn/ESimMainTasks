using ESimMainTasks.PageObjects;
using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace ESimMainTasks.Steps
{
    [Binding]
    public sealed class ESimMainTasksSteps
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

            var jsonSettingsContent = File.ReadAllText(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\ESimMainTasks\\ESimMainTasks\\AppSettings.json");
            //var jsonSettingsContent = File.ReadAllText("AppSettings.json");
            AppSettings = JsonConvert.DeserializeObject<AppSettings>(jsonSettingsContent);

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
            //WebDriver.Url = "https://primera.e-sim.org/";
            //basePage.GoToBasePage();
        }
        
        [Given(@"login to service")]
        public void GivenLogin()
        {

            basePage.SetLoginButton()
                //.SetLoginInput("sledzik") //AppSettings
                .SetLoginInput(AppSettings.TestUserName)
                .SetPasswordInput(AppSettings.TestUserPassword) //"dieh@rd"
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
