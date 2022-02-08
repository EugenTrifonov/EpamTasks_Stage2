using OpenQA.Selenium;
using Task5.Base;

namespace Task5.GoogleCloud
{
    public class SearchResultsPage:BasePage
    {
        private readonly IWebElement _firstResult = Driver.FindElementByXpath("//div[contains(@class,'result')]//a[contains(@class,'title')]");

        public SearchResultsPage(IWebDriver driver) : base(driver) 
        {
            _driver.FindElement(By.XPath("//title[contains(text(),'Search')]"));
        }

        public CalculatorPage ClickFirstResult() 
        {
            _firstResult.Click();
            
            return new CalculatorPage(_driver);
        }
    }
}
