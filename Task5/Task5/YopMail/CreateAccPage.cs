using OpenQA.Selenium;
using Task5.Base;

namespace Task5.YopMail
{
    public class CreateAccPage : BasePage
    {
        private readonly By _randomAccCreateButton = By.XPath("//a[@href='email-generator']");
        private readonly By _addresseelocator = By.XPath("//script[contains(text(),'login=')]/..");
        private readonly By _goToMaleButton = By.XPath("//span[contains(text(),'Проверить')]");

        public static string _addressee { get; private set; }

        public CreateAccPage(IWebDriver driver) : base(driver)
        {
            _driver.FindElement(By.XPath("//title[contains(text(),'YOPmail')]"));
        }

        public InboxPage CreateRandomAcc()
        {
            _driver.FindElement(_randomAccCreateButton).Click();
            _addressee = _driver.FindElement(_addresseelocator).Text;
            _driver.FindElement(_goToMaleButton).Click();

            return new InboxPage(_driver);
        }
    }
}
