using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task5.Base;

namespace Task5.GoogleCloud
{
    public class GoogleUtilities
    {
        private static IWebDriver _driver;
        private const string _url = "https://cloud.google.com/";

        public static SearchPage StartUpBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_url);

            return new SearchPage(_driver);
        }

        public static void CheckCalculatorPage(string text)
        {
            while (!_driver.Url.Contains("calculator"))
            {
                _driver.Navigate().GoToUrl(_url);

                SearchPage page = new SearchPage(_driver);
                page.Search(text).ClickFirstResult();
            }
        }

        public static void SendPriceToMail(string email)
        {
            CalculatorPage page = new CalculatorPage(_driver);

            page.EmailEstimate(email);
        }

        public static string GetPrice()
        {
            CalculatorPage page = new CalculatorPage(_driver);

            return page.GetPrice();
        }

        public static void EnterIframe()
        {
            IWebElement iframe = _driver.FindElement(By.XPath("*//iframe"));
            _driver.SwitchTo().Frame(iframe);
            iframe = _driver.FindElement(By.XPath("//iframe[@id='myFrame']"));
            _driver.SwitchTo().Frame(iframe);
        }
    }
}
