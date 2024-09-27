using BoDi;
using IconTestFramework.Core.Config;
using IconTestFramework.UIAutomation.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Hooks
{
    [Binding]
    public class TestInitializer
    {
        private DriverManager driverManager;
        private readonly IObjectContainer container;

        public TestInitializer(IObjectContainer container)
        {
            this.container = container;
        }

        //[Scope(Tag = "web")]
        [BeforeScenario(Order = 0)]
        public void StartBrowser()
        {
            //getting the browser driver
            driverManager = new ChromeDriverManager();
            IWebDriver driver = driverManager.GetWebDriver();

            //getting the base url
            driver.Url = Configurator.BaseUrl;
            driver.Navigate();

            container.RegisterInstanceAs(driver);
        }

        [AfterScenario(Order = 1)]
        public void CloseBrowser()
        {
            var driver = container.Resolve<IWebDriver>();
            driverManager.CloseWebDriver();
        }
    }
}