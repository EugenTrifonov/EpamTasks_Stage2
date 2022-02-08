using OpenQA.Selenium;

namespace Task5.Base
{
    public abstract class BasePage
    {
        private const int _waitTime = 15;

        protected static IWebDriver _driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
