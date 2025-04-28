using AmazonAutomation.Pages;
using AmazonAutomation.Utilities;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AmazonAutomation.Tests
{
    [TestFixture]
    public class AmazonTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetWebDriver();

            driver.Navigate().GoToUrl("https://www.amazon.com/");

            Utilities.Logger<AmazonTests>.GetLogger().LogWarning("Please provide captcha if shows");

            Thread.Sleep(20000);
            Utilities.Logger<AmazonTests>.GetLogger().LogInformation("Navigated to Amazon.com");
            homePage = new HomePage(driver);

        }

        [Test, Order(1)]
        public void SelectCategoryTest()
        {
            homePage.SelectCategory("Software");
            Utilities.Logger<AmazonTests>.GetLogger().LogInformation("Selected 'Software' category from dropdown.");

        }

        [Test, Order(2)]
        public void SearchItemTest()
        {
            homePage.SearchItem("games");
            Utilities.Logger<AmazonTests>.GetLogger().LogInformation("Searched for 'games'.");
            
        }

        [Test, Order(3)]
        public void CloseBrowserTest()
        {
            Utilities.Logger<AmazonTests>.GetLogger().LogInformation("Closing the browser.");
            DriverFactory.QuitDriver();
        }
    }
}
