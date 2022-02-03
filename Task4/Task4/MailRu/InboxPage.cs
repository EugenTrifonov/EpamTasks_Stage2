using OpenQA.Selenium;

namespace Task4.MailRu
{
    public class InboxPage:BasePage
    {
        private const string message = "//a[contains(@class, 'letter-list-item')][1]";
        private readonly By _lastMessage = By.XPath(message);
        private readonly By _lastMessageAddressee=By.XPath("//a[contains(@class, 'letter-list-item')][1]/descendant::span[contains(@title, '@')]");
        private readonly By _replyButton = By.XPath("//span[@title='Ответить']");
        private readonly By _sendReplyButton = By.XPath("//span[@class='button2__txt']");
        private readonly By _messageField = By.XPath("//div[@role='textbox']//div[1]");
        private readonly By _messageText = By.XPath("//span[@class='ll-sp__normal']");
        private readonly By _messageStatus = By.XPath(message+"//div[contains(@class,'read-status')]//span");
        private readonly By _sendmessageButton = By.XPath("//span[contains(text(),'Написать письмо')]");
        private readonly By _confirmsendButton=By.XPath("//span[contains(@title,'Отправить')]");
        private readonly By _sendMessageAddressee = By.XPath("//div[contains(@class,'head_container')]//input");
        private readonly By _messagesCount = By.XPath("//span[@class='badge__text']");

        public InboxPage(IWebDriver driver) : base(driver) { }

        public bool IsLastMessageUnread() 
        {
            return Driver.FindElement(_messageStatus).GetAttribute("class").Contains("is-active");
        }

        public bool IsAddresseeCorrect(string addressee)
        {
            return Driver.FindElement(_lastMessageAddressee).GetAttribute("title").Contains(addressee);
        }

        public InboxPage OpenMessage()
        {
            Driver.FindElement(_lastMessage).Click();

            return this;
        }

        public string GetMessageText() 
        {
            return Driver.FindElement(_messageText).Text;
        }

        public InboxPage OpenReplyWindow()
        {
            Driver.FindElement(_replyButton).Click();

            return this;
        }

        public InboxPage SendReply(string message) 
        {
            Driver.FindElement(_messageField).SendKeys(message);
            Driver.FindElement(_confirmsendButton).Click();

            return this;        
        }

        public InboxPage SendMessage(string addressee,string message) 
        {
            Driver.FindElement(_sendmessageButton).Click();
            Driver.FindElement(_sendMessageAddressee).SendKeys(addressee);
            Driver.FindElement(_messageField).SendKeys(message);
            Driver.FindElement(_confirmsendButton).Click();

            return this;
        }

        public int GetMessagesCount()
        {
            return System.Convert.ToInt32(Driver.FindElement(_messagesCount).Text);
        }
    }
}
