using OpenQA.Selenium;
using System.Threading;
using Task5.Base;

namespace Task5.YopMail
{
    public static class YopMailUtilities
    {
        public static string _url = "https://yopmail.com/ ";

        private const int _maxWaitTime = 60000;
        private const int _waitInterval = 5000;

        public static int _messagesCount;

        private static IWebDriver _driver = Driver.GetInstance();

        public static CreateAccPage OpenYopMail()
        {
            _driver.Navigate().GoToUrl(_url);

            return new CreateAccPage(_driver);
        }

        public static InboxPage WaitForMessage()
        {
            int waitTime = 0;

            InboxPage page = new InboxPage(_driver);

            while (waitTime < _maxWaitTime)
            {
                if (page.GetMessagesCount() == _messagesCount)
                {
                    _driver.Navigate().Refresh();
                    Thread.Sleep(_waitInterval);
                    waitTime += _waitInterval;
                }
                else
                {
                    _messagesCount = page.GetMessagesCount();
                    break;
                }
            }

            return page;
        }

        public static string GetMessageContent()
        {
            InboxPage page = new InboxPage(_driver);

            return page.GetMessageContent();
        }

        public static string GetPriceFromMessage() 
        {
            InboxPage page = new InboxPage(_driver);

            return page.GetPrice();
        }

        public static bool IsPriceCorrect(string price) 
        {
            InboxPage page = new InboxPage(_driver);

            return price.Contains(page.GetPrice()); 
        } 
    }
}
