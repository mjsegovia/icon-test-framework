using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public class SeleniumHelper
{
    private readonly IWebDriver _driver;
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10); 

    public SeleniumHelper(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool WaitForElementToBeVisible(By locator)
    {
        try
        {
            // Create a WebDriverWait with timeout and polling interval
            WebDriverWait wait = new WebDriverWait(_driver, _timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            // Wait for the element to be displayed
            return wait.Until(driver =>
            {
                var element = driver.FindElement(locator);
                return element.Displayed;
            });
        }
        catch (WebDriverTimeoutException)
        {
            //If the element is not displayed return false
            return false;
        }
    }
}