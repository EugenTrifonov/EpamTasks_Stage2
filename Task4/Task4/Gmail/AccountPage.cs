using OpenQA.Selenium;

namespace Task4.Gmail
{
    public class AccountPage : BasePage
    {
        private readonly By _personalDataButton = By.XPath("//div[contains(text(),'Личная')]/..");
        private readonly By _nameButton = By.XPath("//a[contains(@aria-label,'Имя')]");
        private readonly By _nameField = By.XPath("//span[text()='Имя']/following::input");
        private readonly By _confirmChangesButton = By.XPath("//span[text()='Сохранить']");
        private readonly By _backToAccButton = By.XPath("//span[text()='Аккаунт']");
        private readonly By _nameTextField = By.XPath("//a[contains(@aria-label,'Имя')]//following::div[3]");

        public AccountPage(IWebDriver driver) : base(driver) { }

        public AccountPage OpenPersonalData()
        {
            Driver.FindElements(_personalDataButton)[1].Click();

            return this;
        }
        public AccountPage ChangeName(string newName)
        {
            Driver.FindElement(_nameButton).Click();
            Driver.FindElement(_nameField).Clear();
            Driver.FindElement(_nameField).SendKeys(newName);
            Driver.FindElement(_confirmChangesButton).Click();
            Driver.FindElements(_backToAccButton)[1].Click();

            return this;
        }

        public string GetNameAndSurname()
        {
            return Driver.FindElement(_nameTextField).Text;
        }

    }
}
