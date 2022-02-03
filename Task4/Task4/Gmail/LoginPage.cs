using OpenQA.Selenium;

namespace Task4.Gmail
{
    public class LoginPage : BasePage
    {
        private readonly By _singinButton = By.XPath("//a[@data-action='sign in']");
        private readonly By _usernameField = By.XPath("//input[@type='email']");
        private readonly By _furtherButton = By.XPath("//span[text()='Далее']/..");
        private readonly By _passwordField = By.XPath("//input[@type='password']");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage EnterUsername(string username)
        {
            Driver.FindElement(_singinButton).Click();
            Driver.FindElement(_usernameField).SendKeys(username);

            return this;
        }

        public LoginPage ConfirmUsernameOrPassword()
        {
            Driver.FindElement(_furtherButton).Click();

            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            Wait.Until(x => x.FindElement(_passwordField).Displayed == true);
            Driver.FindElement(_passwordField).SendKeys(password);

            return this;
        }
    }
}
