using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Steps
{
    public abstract class BaseSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        protected BaseSteps(IWebDriver driver, ScenarioContext context)
        {
            _driver = driver;
            _scenarioContext = context;
        }

        // Cleanup after scenario by closing the browser
        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
