using OpenQA.Selenium;

namespace IconTestFramework.UIAutomation.Driver
{
    public abstract class DriverManager
    {
        protected IWebDriver driver;

        protected abstract void CreateWebDriver();

        public void CloseWebDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                CreateWebDriver();
            }
            return driver;
        }
    }
}