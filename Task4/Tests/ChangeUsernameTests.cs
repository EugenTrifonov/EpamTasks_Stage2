using NUnit.Framework;
using Task4.MailRu;
using Task4.Gmail;

namespace Tests
{
    public class ChangeUsernameTests
    {
        private const string _mailUsername = "testmailacc1@mail.ru";
        private const string _mailPassword = "sdfsfdj12324try";
        private const string _gmailUsername = "acc123sdfsfs@gmail.com";
        private const string _gmailPassword = "sfdsffsdgtryhth565g";
        private const string _message = "dfgdfhfsa";
        private const string _newName = "cxvcbvdsa";

        [SetUp]
        public void Setup()
        {
            MailRuUtilities.StartUpBrowser();
            MailRuUtilities.SingIn(_mailUsername, _mailPassword);
            MailRuUtilities.CountMessages();

            GmailUtilities.StartUpBrowser();
            GmailUtilities.SingIn(_gmailUsername, _gmailPassword);
            GmailUtilities.SendMessage(_mailUsername, _message);
            GmailUtilities.CountMessages();

            MailRuUtilities.WaitForMessage();
            MailRuUtilities.SendReply(_newName);
        }

        [Test]
        public void ChangeUsernameTest()
        {
            GmailUtilities.WaitForMessage();
            GmailUtilities.ChangePesonalData(GmailUtilities.GetLastMessageContent());

            Assert.IsTrue(GmailUtilities.IsNameCorrect(_newName));
        }

        [TearDown]
        public void TearDown()
        {
            GmailUtilities.CloseBrowser();
            MailRuUtilities.CloseBrowser();
        }
    }
}
