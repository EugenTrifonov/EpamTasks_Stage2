using NUnit.Framework;
using Task4.MailRu;
using Task4.Gmail;

namespace Tests
{
    public class SendMessageTests
    {
        private const string _mailUsername = "testmailacc1@mail.ru";
        private const string _mailPassword = "sdfsfdj12324try";
        private const string _gmailUsername = "acc123sdfsfs@gmail.com";
        private const string _gmailPassword = "sfdsffsdgtryhth565g";
        private static int _mailruMessagesCount;
        private const string message = "zxcvbn";

        [SetUp]
        public void Setup()
        {
            MailRuUtilities.StartUpBrowser();
            MailRuUtilities.SingIn(_mailUsername, _mailPassword);
            MailRuUtilities.CountMessages();

            _mailruMessagesCount = MailRuUtilities._messagesCount;
            GmailUtilities.StartUpBrowser();
            GmailUtilities.SingIn(_gmailUsername, _gmailPassword);
            GmailUtilities.SendMessage(_mailUsername, message);
            MailRuUtilities.WaitForMessage();
        }

        [Test]
        public void IsMessageWithCorrectAdresseeAndContentCame()
        {
            Assert.IsTrue(MailRuUtilities.GetMessagesCount() != _mailruMessagesCount);
            Assert.IsTrue(MailRuUtilities.LastMessageCheck(_gmailUsername));
            Assert.IsTrue(MailRuUtilities.GetLastMessageContent() == message);
        }

        [TearDown]
        public void TearDown()
        {
            GmailUtilities.CloseBrowser();
            MailRuUtilities.CloseBrowser();
        }
    }
}
