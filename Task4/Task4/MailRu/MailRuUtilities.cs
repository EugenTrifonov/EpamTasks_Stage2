using OpenQA.Selenium;
using System.Threading;

namespace Task4.MailRu
{
    public class MailRuUtilities
    {
        private const string _url = "https://mail.ru/";
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
            page.ConfirmUsername();
            page.EnterPassword(password);
            return page.ConfirmPassword();
        }

        public static void EnterUsername(string username)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterUsername(username);
            page.ConfirmUsername();
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

        public static void EnterPassword(string password)
        {
            LoginPage page = new LoginPage(_driver);
            page.EnterPassword(password);
            page.ConfirmPassword();
        }

        public static bool LastMessageCheck(string addressee)
        {
            InboxPage page = new InboxPage(_driver);

            return page.IsAddresseeCorrect(addressee) && page.IsLastMessageUnread();
        }

        public static void SendMessage(string addressee, string message)
        {
            InboxPage page = new InboxPage(_driver);

            page.SendMessage(addressee, message);
        }

        public static void SendReply(string replyMessage)
        {
            InboxPage page = new InboxPage(_driver);

            page.OpenMessage();
            page.OpenReplyWindow();
            page.SendReply(replyMessage);
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
