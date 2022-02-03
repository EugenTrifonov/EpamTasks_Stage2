using OpenQA.Selenium;

namespace Task4.MailRu
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.XPath("//input[@name='login']");
        private readonly By _enterPasswordButton = By.XPath("//button[@class='button svelte-1da0ifw']");
        private readonly By _passwordField = By.XPath("//input[@name='password']");
        private readonly By _enterButton = By.XPath("//button[@class='second-button svelte-1da0ifw']");
        private readonly By _incorrectUsername = By.XPath("//div[contains(text(),'Неверное')]");
        private readonly By _incorrectPassword = By.XPath("//div[contains(text(),'Неверное имя или пароль')]");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage EnterUsername(string username)
        {
            Driver.FindElement(_usernameField).SendKeys(username);

            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            Driver.FindElement(_passwordField).SendKeys(password);

            return this;
        }

        public LoginPage ConfirmUsername()
        {
            Driver.FindElement(_enterPasswordButton).Click();

            return this;
        }

        public InboxPage ConfirmPassword()
        {
            Driver.FindElement(_enterButton).Click();

            return new InboxPage(Driver);
        }

        public bool IsUsernameCorrect()
        {
            try
            {
                Driver.FindElement(_incorrectUsername);

                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool IsPasswordCorrect()
        {
            try
            {
                Driver.FindElement(_incorrectPassword);

                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
