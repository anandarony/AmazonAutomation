using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace AmazonAutomation.Pages
{
    internal class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement CategoryDropdown => driver.FindElement(By.CssSelector("#searchDropdownBox"));

        private IWebElement SearchBox => driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
        private IWebElement SearchButton => driver.FindElement(By.CssSelector("#nav-search-submit-button"));

        public void SelectCategory(string category)
        {
            var selectElement = new SelectElement(CategoryDropdown);
            selectElement.SelectByText(category);
        }

        public void SearchItem(string item)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#twotabsearchtextbox")));
            SearchBox.Clear();
            SearchBox.SendKeys(item);
            SearchButton.Click();
        }
    }
}

