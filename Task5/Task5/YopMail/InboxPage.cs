using OpenQA.Selenium;
using Task5.Base;

namespace Task5.YopMail
{
    public class InboxPage:BasePage
    {
        private static readonly By _messagesCountlocator = By.XPath("//div[@id='nbmail']");
        private static readonly By _messageContent = By.XPath("//div[@id='mail']//div");
        private static readonly By _priceLocator = By.XPath("//h3[text()!='Total Estimated Monthly Cost']");

        public InboxPage(IWebDriver driver):base(driver)
        {
            _driver.FindElement(By.XPath("//title[contains(text(),'Входящие')]"));
            YopMailUtilities._messagesCount = GetMessagesCount();
        }

        public int GetMessagesCount() 
        {
            string count = _driver.FindElement(_messagesCountlocator).Text;
            
            return System.Convert.ToInt32(count[0]);
        }

        public string GetMessageContent() 
        {
            string result = _driver.FindElement(_messageContent).Text;

            return result;
        }

        public string GetPrice() 
        {
            IWebElement iframe = _driver.FindElement(By.XPath("*//iframe[@name='ifmail']"));
            _driver.SwitchTo().Frame(iframe);
            string result = _driver.FindElement(_priceLocator).Text;

            return result;
        }
    }
}
