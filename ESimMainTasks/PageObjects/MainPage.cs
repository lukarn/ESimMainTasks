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

        [FindsBy(How = How.CssSelector, Using = "#taskButtonTrain>a")]
        private IWebElement trainTaskButton { get; set; }

        public void SetTrainTaskButtonn()
        {
            WaitAndClick(this.trainTaskButton);
        }

        [FindsBy(How = How.CssSelector, Using = "a#myPlaces")]
        private IWebElement menuMyPlacesButton { get; set; }

        public MainPage SetMenuMyPlacesButton()
        {
            WaitAndClick(this.menuMyPlacesButton);

            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "a[href*='train']")]
        private IWebElement menuTrainButton { get; set; }
        public void SetMenuTrainButton()
        {
            WaitAndClick(this.menuTrainButton);

        }

        //    @FindBy(css = "a[href*='work']")
        //private WebElement menuWorkButton;
        [FindsBy(How = How.CssSelector, Using = "a[href*='work']")]
        private IWebElement menuWorkButton { get; set; }
        public void SetMenuWorkButton()
        {
            WaitAndClick(this.menuWorkButton);

        }

        //    @FindBy(css = "#taskButtonWork>a")
        //private WebElement workTaskButton;
        [FindsBy(How = How.CssSelector, Using = "#taskButtonWork>a")]
        private IWebElement workTaskButton { get; set; }
        public void SetWorkTaskButton()
        {
            WaitAndClick(this.workTaskButton);

        }





        /////////////////////////////////////////////////








        //    public void setWorkTaskButton()
        //    {
        //        clickElement(this.workTaskButton);
        //    }



        //    public void setMenuWorkButton()
        //    {
        //        clickElement(this.menuWorkButton);
        //    }







    }
}
