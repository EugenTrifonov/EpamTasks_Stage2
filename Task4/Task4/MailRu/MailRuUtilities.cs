using OpenQA.Selenium;
using System.Threading;

namespace Task4.MailRu
{
    public class MailRuUtilities
    {
        private const string _url = "https://mail.ru/";
        private static IWebDriver _driver;
        public static int _messagesCount { get; private set; }
        private const int _waitTime = 90000;
        private const int _waitInterval = 5000;

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

            return page.EnterUsername(username).ConfirmUsername().EnterPassword(password).ConfirmPassword();
        }

        public static LoginPage EnterUsername(string username)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterUsername(username);

            return page.ConfirmUsername();
        }

        public static bool IsUsernameCorrect()
        {
            LoginPage page = new LoginPage(_driver);

            return page.IsUsernameCorrect();
        }

        public static bool IsPasswordCorrect()
        {
            LoginPage page = new LoginPage(_driver);

            return page.IsPasswordCorrect();
        }

        public static InboxPage EnterPassword(string password)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterPassword(password);
            return page.ConfirmPassword();
        }

        public static bool LastMessageCheck(string addressee)
        {
            InboxPage page = new InboxPage(_driver);

            return page.IsAddresseeCorrect(addressee) && page.IsLastMessageUnread();
        }

        public static InboxPage SendMessage(string addressee, string message)
        {
            InboxPage page = new InboxPage(_driver);

            return page.SendMessage(addressee, message);
        }

        public static InboxPage SendReply(string replyMessage)
        {
            InboxPage page = new InboxPage(_driver);

            return page.OpenMessage().OpenReplyWindow().SendReply(replyMessage);
        }

        public static bool CheckMessageContent(string content)
        {
            InboxPage page = new InboxPage(_driver);

            return page.GetMessageText() == content;
        }

        public static string GetLastMessageContent()
        {
            InboxPage page = new InboxPage(_driver);
            return page.GetMessageText();
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
