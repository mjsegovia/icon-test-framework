using OpenQA.Selenium;

namespace IconTestFramework.UIAutomation.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected string _baseUrL;
        protected readonly SeleniumHelper _helper;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _helper = new SeleniumHelper(driver);
        }

        //public abstract void NavigateTo();

        public abstract bool IsAt();
    }
}
