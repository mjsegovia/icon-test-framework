using IconTestFramework.Core.Domain;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace IconTestFramework.UIAutomation.Driver
{
    public class ChromeDriverManager : DriverManager
    {
        protected override void CreateWebDriver()
        {
            string path = Directory.GetCurrentDirectory();
            string chromeDriverPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\IconTestFramework.UIAutomation\Driver\WebDrivers"));
        
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-search-engine-choice-screen");
           // options.AddArgument("disable-web-security");
           // options.AddArgument("headless");
          //  options.AddArgument("user-data-dir");
         //   options.AddArgument("allow-running-insecure-content");
         //   options.AddArgument("--incognito");
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            /* options.AddArgument("no-first-run");
             options.AddArgument("no-default-browser-check");
             options.AddArgument("disable-default-apps");*/

          //  options.AddArgument("--disable-first-run-ui");
            /* options.AddArgument("window-size=1980,960");
             options.AddArgument("no-sandbox");
             options.AddArgument("start-maximized");*/
            options.AddExcludedArgument("disable-popup-blocking");
            

            this.driver = new ChromeDriver(chromeDriverPath, options);
        }
    }
}