using OpenQA.Selenium;

namespace ESimMainTasks.PageObjects
{
    sealed class MainPage : Page
    {
        public MainPage(IWebDriver webDriver, IAppSettings settings) : base(webDriver, settings)
        {
        }

        public override void WaitUntilPageIsDisplayed()
        {
            WaitForVisible(TrainTaskButton);
        }

        private static By TrainTaskButton => By.CssSelector("#taskButtonTrain>a");

        public void SetTrainTaskButtonn()
        {
            ClickElement(TrainTaskButton);
        }

        private static By MenuMyPlacesButton => By.CssSelector("a#myPlaces");

        public MainPage SetMenuMyPlacesButton()
        {
            ClickElement(MenuMyPlacesButton);

            return this;
        }

        private static By MenuTrainButton => By.CssSelector("a[href*='train']");

        public void SetMenuTrainButton()
        {
            ClickElement(MenuTrainButton);
        }

        private static By MenuWorkButton => By.CssSelector("a[href*='work']");

        public void SetMenuWorkButton()
        {
            ClickElement(MenuWorkButton);

        }

        private static By WorkTaskButton => By.CssSelector("#taskButtonWork>a");

        public void SetWorkTaskButton()
        {
            ClickElement(WorkTaskButton);
        }


    }
}
