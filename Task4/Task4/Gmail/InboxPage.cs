using OpenQA.Selenium;

namespace Task4.Gmail
{
    public class InboxPage : BasePage
    {
        private const string message = "//table[@role='grid']//tr[1]";
        private readonly By _lastMessage = By.XPath(message);
        private readonly By _backToMail = By.XPath("//a[@title='Почта']");
        private readonly By _typeMessageButton = By.XPath("//div[contains(text(),'Написать')]");
        private readonly By _addresseeField = By.XPath("//textarea[contains(@name,'to')]");
        private readonly By _messageTextbox = By.XPath("//div[@role='textbox']");
        private readonly By _confirmSendButton = By.XPath("//div[text()='Отправить']");
        private readonly By _lastMessageAddressee = By.XPath(message + "//span[@name!='я']");
        private readonly By _MessageContent = By.XPath("//div[@class='a3s aiL ']/div[2]/div[1]");
        private readonly By _sendMessageConfirmText = By.XPath("//span[contains(text(),'Сообщение отправлено')]");
        private readonly By _accountButton = By.XPath("//a[contains(@aria-label,'Аккаунт')]");
        private readonly By _accountSettingsButton = By.XPath("//a[contains(text(),'аккаунтом')]");
        private readonly By _messagesCount = By.XPath("//div[@class='bsU']");

        public InboxPage(IWebDriver driver) : base(driver) { }

        public bool IsAddresseeCorrect(string addressee)
        {
            string email = Driver.FindElement(_lastMessageAddressee).GetAttribute("email");

            return email.Contains(addressee);
        }

        public InboxPage OpenMessage()
        {
            Driver.FindElement(_lastMessage).Click();

            return this;
        }

        public string GetLastMessageText()
        {
            Driver.FindElement(_lastMessage).Click();
            string content = Driver.FindElement(_MessageContent).Text;
            Driver.FindElements(_backToMail)[1].Click();

            return content;
        }

        public InboxPage SendMessage(string addressee, string message)
        {
            Driver.FindElement(_typeMessageButton).Click();
            Driver.FindElement(_addresseeField).SendKeys(addressee);
            Driver.FindElement(_messageTextbox).SendKeys(message);
            Driver.FindElement(_confirmSendButton).Click();
            Driver.FindElement(_sendMessageConfirmText);

            return this;
        }

        public AccountPage OpenAccountSettings()
        {
            Driver.FindElement(_accountButton).Click();
            Driver.FindElement(_accountSettingsButton).Click();
            GmailUtilities.ChangeActiveTab(1);

            return new AccountPage(Driver);
        }

        public int GetMessagesCount()
        {
            System.Threading.Thread.Sleep(3000);
            string count = Driver.FindElement(_messagesCount).Text;

            return System.Convert.ToInt32(count);     
        }
    }
}
