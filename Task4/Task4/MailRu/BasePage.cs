using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task4.MailRu
{
    public class BasePage
    {
        private readonly int _waitTime = 15;

        public WebDriverWait Wait { get; }

        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(_waitTime));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_waitTime);
        }
    }
}
