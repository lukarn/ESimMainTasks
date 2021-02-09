using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ESimMainTasks.PageObjects;
using System.Threading;
using FluentAssertions;

namespace ESimMainTasks.Steps
{
    [Binding]
    public class ESimMainTasksSteps
    {
        IWebDriver webDriver;

        

        [Given(@"launch browser")]
        public void GivenLaunchBrowser()
        {
            webDriver = new ChromeDriver("C:\\selGrid");

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

        [When(@"click Trenuj button")]
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



        [Then(@"the timer to next train should be present")]
        public void ThenTheTimerToNextTrainShouldBePresent()
        {
            var trainPage = new TrainPage(webDriver);
            trainPage.TrainCheck().Should().BeTrue();

        }
    }
}
