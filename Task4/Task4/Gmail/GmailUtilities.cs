using OpenQA.Selenium;
using System.Threading;

namespace Task4.Gmail
{
    public class GmailUtilities
    {
        private const string _url = "https://www.google.com/intl/ru/gmail/about/";
        private static IWebDriver _driver;
        public static int _messagesCount { get; private set; }

        public static void StartUpBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_url);
        }

        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }

        public static InboxPage SingIn(string username, string password)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterUsername(username);
            page.ConfirmUsernameOrPassword();
            page.EnterPassword(password);
            page.ConfirmUsernameOrPassword();

            return new InboxPage(_driver); 
        }

        public static void SendMessage(string addressee, string message)
        {
            InboxPage page = new InboxPage(_driver);
            page.SendMessage(addressee, message);
        }

        public static string GetLastMessageContent()
        {
            InboxPage page = new InboxPage(_driver);
            return page.GetLastMessageText();
        }

        public static void ChangePesonalData(string newName)
        {
            InboxPage page = new InboxPage(_driver);
            AccountPage accPage = page.OpenAccountSettings();
            accPage.OpenPersonalData();
            accPage.ChangeName(newName);
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

        public static void WaitForMailFromAddressee(string addressee)
        {
            InboxPage page = new InboxPage(_driver);
            int waitTime = 0;

            while (!page.IsAddresseeCorrect(addressee))
            {
                Thread.Sleep(5000);
                waitTime += 5000;
                _driver.Navigate().Refresh();

                if (waitTime > 90000)
                {
                    break;
                }
            }
        }
        public static void CountMessages()
        {
            InboxPage page = new InboxPage(_driver);
            _messagesCount = page.GetMessagesCount();
        }

        public static int GetMessagesCount()
        {
            InboxPage page = new InboxPage(_driver);
            return page.GetMessagesCount();
        }

        public static void WaitForMessage()
        {
            InboxPage page = new InboxPage(_driver);
            int waitTime = 0;

            while (waitTime < 90000)
            {
                if (page.GetMessagesCount() == _messagesCount)
                {
                    _driver.Navigate().Refresh();
                    Thread.Sleep(5000);
                    waitTime += 5000;
                }
                else
                {
                    _messagesCount = page.GetMessagesCount();
                    break;
                }

            }
        }
    }
}
