using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAutomation.Utilities
{
    public static class DriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {

                
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.SuppressInitialDiagnosticInformation = true;

                service.SuppressInitialDiagnosticInformation = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--log-level=3");  // Only show errors
                options.AddExcludedArgument("enable-logging");
                driver = new ChromeDriver(service, options);

                driver.Manage().Window.Maximize();

            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
