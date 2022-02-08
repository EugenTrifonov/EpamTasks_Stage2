using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task5.Base
{
    public class Driver
    {
        private static IWebDriver _driver;

        private const int _waitTime = 10;

        private static WebDriverWait Wait { get; set; }

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private Driver() { }

        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                switch (TestContext.Parameters["browser"])
                {
                    case ("Firefox"):
                        _logger.Info("Running Firefox");
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        break;
                    default:
                        _logger.Info("Running Chrome");
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        _driver = new ChromeDriver();
                        break;
                }

                Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(_waitTime));
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(_waitTime);
            }

            return _driver;
        }

        public static void CloseBrowser()
        {
            _logger.Info("Closing Browser");
            _driver.Quit();
            _driver = null;
        }

        public static IWebElement FindElementByXpath(string path) 
        {
            return _driver.FindElement(By.XPath(path));
        }

        public static void WaitUntilElementIsVissibleAndActive(By locator) 
        {
            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(0);

            Wait.Until(x => x.FindElement(locator).Displayed && x.FindElement(locator).Enabled);

            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(_waitTime);
        }
    }
}
