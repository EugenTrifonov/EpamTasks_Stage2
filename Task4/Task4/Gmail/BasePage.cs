using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task4.Gmail
{
    public abstract  class BasePage
    {
        private const int _waitTime = 15;

        protected WebDriverWait Wait { get; }

        protected static IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(_waitTime));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_waitTime);
        }
    }
}
