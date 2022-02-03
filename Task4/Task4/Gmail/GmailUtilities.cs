using OpenQA.Selenium;
using System.Threading;

namespace Task4.Gmail
{
    public class GmailUtilities
    {
        private const string _url = "https://www.google.com/intl/ru/gmail/about/";
        private static IWebDriver _driver;
        private const int _waitTime = 90000;
        private const int _waitInterval = 5000;

        public static int _messagesCount { get; private set; }


        public static LoginPage StartUpBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_url);

            return new LoginPage(_driver);
        }

        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }

        public static InboxPage SingIn(string username, string password)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterUsername(username).ConfirmUsernameOrPassword().EnterPassword(password).ConfirmUsernameOrPassword();

            return new InboxPage(_driver);
        }

        public static InboxPage SendMessage(string addressee, string message)
        {
            InboxPage page = new InboxPage(_driver);

            return page.SendMessage(addressee, message);
        }

        public static string GetLastMessageContent()
        {
            InboxPage page = new InboxPage(_driver);

            return page.GetLastMessageText();
        }

        public static AccountPage ChangePesonalData(string newName)
        {
            InboxPage page = new InboxPage(_driver);
            AccountPage accPage = page.OpenAccountSettings();
            accPage.OpenPersonalData();

            return accPage.ChangeName(newName);
        }

        public static bool IsNameCorrect(string name)
        {
            AccountPage page = new AccountPage(_driver);
            page.OpenPersonalData();
            return page.GetNameAndSurname().Contains(name);
        }

        public static void ChangeActiveTab(int tabNumber)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[tabNumber]);
        }

        public static InboxPage WaitForMailFromAddressee(string addressee)
        {
            InboxPage page = new InboxPage(_driver);
            int waitTime = 0;

            while (!page.IsAddresseeCorrect(addressee))
            {
                Thread.Sleep(_waitInterval);
                waitTime += _waitInterval;
                _driver.Navigate().Refresh();

                if (waitTime > _waitTime)
                {
                    break;
                }
            }

            return page;
        }

        public static InboxPage CountMessages()
        {
            InboxPage page = new InboxPage(_driver);
            _messagesCount = page.GetMessagesCount();

            return page;
        }

        public static int GetMessagesCount()
        {
            InboxPage page = new InboxPage(_driver);
            return page.GetMessagesCount();
        }

        public static InboxPage WaitForMessage()
        {
            InboxPage page = new InboxPage(_driver);
            int waitTime = 0;

            while (waitTime < _waitTime)
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
    }
}
