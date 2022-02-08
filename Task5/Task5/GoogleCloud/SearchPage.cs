using OpenQA.Selenium;
using Task5.Base;

namespace Task5.GoogleCloud
{
    public class SearchPage:BasePage
    {
        private readonly IWebElement _searchField = Driver.FindElementByXpath("//input[@role='searchbox']");

        public SearchPage(IWebDriver driver) : base(driver) 
        { 
            _driver.FindElement(By.XPath("//title[contains(text(),'Cloud')]"));
        }

        public SearchResultsPage Search(string text) 
        {
            _searchField.Click();
            _searchField.SendKeys(text);
            _searchField.SendKeys(Keys.Enter);

            return new SearchResultsPage(_driver);
        }
    }
}
