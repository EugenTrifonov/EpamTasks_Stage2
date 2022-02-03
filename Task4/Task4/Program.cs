using System;
using Task4.Gmail;
using Task4.MailRu;

namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = "zxcvbnn";
            string message="abcdef";
            GmailUtilities.StartUpBrowser();
            GmailUtilities.SingIn("acc123sdfsfs", "sfdsffsdgtryhth565g");
            GmailUtilities.SendMessage("testmailacc1@mail.ru", message);
            GmailUtilities.CountMessages();
            GmailUtilities.CloseBrowser();
            MailRuUtilities.StartUpBrowser();
            MailRuUtilities.SingIn("testmailacc1", "sdfsfdj12324try");
            Console.WriteLine(MailRuUtilities.LastMessageCheck("acc123sdfsfs@gmail.com"));
            Console.WriteLine(MailRuUtilities.CheckMessageContent(message));
            MailRuUtilities.SendReply(name);
            MailRuUtilities.CloseBrowser();
            GmailUtilities.StartUpBrowser();
            GmailUtilities.SingIn("acc123sdfsfs", "sfdsffsdgtryhth565g");
            GmailUtilities.WaitForMessage();
            string newName = GmailUtilities.GetLastMessageContent();
            GmailUtilities.ChangePesonalData(newName);
            Console.WriteLine(GmailUtilities.IsNameCorrect(name));
        }
    }
}
