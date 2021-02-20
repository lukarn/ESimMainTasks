using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using System.Threading;


namespace ESimMainTasks.PageObjects
{
    class MainPage : Page
    {
        private IWebDriver WebDriver;

        public MainPage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
            this.WebDriver = webDriver;
        }

        //private void WaitAndClick(IWebElement webElement)
        //{
        //    Thread.Sleep(1000);
        //    webElement.Click();
        //}

        //[FindsBy(How = How.CssSelector, Using = "#taskButtonTrain>a")]
        //private IWebElement trainTaskButton { get; set; }
        private static By TrainTaskButton => By.CssSelector("#taskButtonTrain>a");

        public void SetTrainTaskButtonn()
        {
            ClickElement(TrainTaskButton);
        }

        //[FindsBy(How = How.CssSelector, Using = "a#myPlaces")]
        //private IWebElement menuMyPlacesButton { get; set; }
        private static By MenuMyPlacesButton => By.CssSelector("a#myPlaces");

        public MainPage SetMenuMyPlacesButton()
        {
            ClickElement(MenuMyPlacesButton);

            return this;
        }

        //[FindsBy(How = How.CssSelector, Using = "a[href*='train']")]
        //private IWebElement menuTrainButton { get; set; }
        private static By MenuTrainButton => By.CssSelector("a[href*='train']");

        public void SetMenuTrainButton()
        {
            //WaitAndClick(this.menuTrainButton);
            ClickElement(MenuTrainButton);

        }

        //    @FindBy(css = "a[href*='work']")
        //private WebElement menuWorkButton;
        //[FindsBy(How = How.CssSelector, Using = "a[href*='work']")]
        //private IWebElement menuWorkButton { get; set; }
        private static By MenuWorkButton => By.CssSelector("a[href*='work']");

        public void SetMenuWorkButton()
        {
            //WaitAndClick(this.menuWorkButton);
            ClickElement(MenuWorkButton);

        }

        //    @FindBy(css = "#taskButtonWork>a")
        //private WebElement workTaskButton;
        //[FindsBy(How = How.CssSelector, Using = "#taskButtonWork>a")]
        //private IWebElement workTaskButton { get; set; }
        private static By WorkTaskButton => By.CssSelector("#taskButtonWork>a");

        public void SetWorkTaskButton()
        {
            //WaitAndClick(this.workTaskButton);
            ClickElement(WorkTaskButton);

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
