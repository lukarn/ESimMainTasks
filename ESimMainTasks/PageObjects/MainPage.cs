using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace ESimMainTasks.PageObjects
{
    class MainPage
    {
        private IWebDriver webDriver;

        public MainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

            PageFactory.InitElements(webDriver, this);
        }

        private void WaitAndClick(IWebElement webElement)
        {
            Thread.Sleep(1000);
            webElement.Click();
        }


        //    @FindBy(css = "")
        //private WebElement trainTaskButton;
        [FindsBy(How = How.CssSelector, Using = "#taskButtonTrain>a")]
        private IWebElement trainTaskButton { get; set; }

        public void SetTrainTaskButtonn()
        {
            WaitAndClick(this.trainTaskButton);
        }

        


        /////////////////////////////////////////////////


    //    @FindBy(css = "#taskButtonWork>a")
    //private WebElement workTaskButton;

    //    @FindBy(css = "a#myPlaces")
    //private WebElement menuMyPlacesButton;

    //    @FindBy(css = "a[href*='work']")
    //private WebElement menuWorkButton;

    //    @FindBy(css = "a[href*='train']")
    //private WebElement menuTrainButton;



    //    public MainPage(WebDriver driver, int wait)
    //    {
    //        super(driver, wait);
    //    }

    //    public void setTrainTaskButton()
    //    {
    //        clickElement(this.trainTaskButton);
    //    }

    //    public void setWorkTaskButton()
    //    {
    //        clickElement(this.workTaskButton);
    //    }

    //    public MainPage setMenuMyPlacesButton()
    //    {
    //        clickElement(this.menuMyPlacesButton);
    //        return this;
    //    }

    //    public void setMenuWorkButton()
    //    {
    //        clickElement(this.menuWorkButton);
    //    }

    //    public void setMenuTrainButton()
    //    {
    //        clickElement(this.menuTrainButton);
    //    }






    }
}
