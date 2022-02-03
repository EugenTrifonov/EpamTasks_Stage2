using NUnit.Framework;
using Task4.MailRu;

namespace Tests
{
    public class LoginTests
    {
        private const string _correctUsername = "testmailacc1";
        private const string _incorrectUsername = "fdgdfgfds32434t54t4t43r32r32r2332fvfdv";
        private const string _correctPassword = "sdfsfdj12324try";
        private const string _incorrectPassword = "gdfhjgyjfd";

        [SetUp]
        public void Setup()
        {
            MailRuUtilities.StartUpBrowser();
        }

        [Test]
        public void CorrectUsernameTest()
        {
            MailRuUtilities.EnterUsername(_correctUsername);

            bool result = MailRuUtilities.IsUsernameCorrect();

            Assert.IsTrue(result);
        }

        [Test]
        public void IncorrectUsernameTest()
        {
            MailRuUtilities.EnterUsername(_incorrectUsername);

            bool result = MailRuUtilities.IsUsernameCorrect();

            Assert.IsFalse(result);
        }

        [Test]
        public void CorrectPasswordTest()
        {
            MailRuUtilities.EnterUsername(_correctUsername);
            MailRuUtilities.EnterPassword(_correctPassword);

            bool result = MailRuUtilities.IsUsernameCorrect();

            Assert.IsTrue(result);
        }

        [Test]
        public void IncorrectPasswordTest()
        {
            MailRuUtilities.EnterUsername(_correctUsername);
            MailRuUtilities.EnterPassword(_incorrectPassword);

            bool result = MailRuUtilities.IsUsernameCorrect();

            Assert.IsFalse(result);
        }

        [Test]
        public void CorrectDataSingInTest()
        {
            var page = MailRuUtilities.SingIn(_correctUsername, _correctPassword);

            Assert.IsTrue(page is InboxPage);
        }

        [Test]
        [TestCase(_incorrectUsername, _correctPassword)]
        [TestCase(_incorrectUsername, _incorrectPassword)]
        public void IncorrectUsernameSingInTest(string username, string password)
        {
            Assert.Throws<OpenQA.Selenium.ElementNotInteractableException>(() => MailRuUtilities.SingIn(username, password));
        }

        [Test]
        [TestCase(_correctUsername, _incorrectPassword)]
        public void CorrectUsernameIncorrectPasswordSingInTest(string username, string password)
        {
            MailRuUtilities.SingIn(username, password);

            Assert.IsFalse(MailRuUtilities.IsPasswordCorrect());
        }

        [Test]
        public void EmptyDataSingInTest()
        {
            Assert.Throws<OpenQA.Selenium.ElementNotInteractableException>(() => MailRuUtilities.SingIn(System.String.Empty, System.String.Empty));
        }

        [TearDown]
        public void TearDown()
        {
            MailRuUtilities.CloseBrowser();
        }
    }
}