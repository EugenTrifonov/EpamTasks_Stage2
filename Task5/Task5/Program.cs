using NLog;
using System;
using Task5.GoogleCloud;
using Task5.Utilities;
using Task5.YopMail;

namespace Task5
{
    class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            GoogleUtilities.StartUpBrowser().
                Search("Google Cloud Platform Pricing Calculator").
                ClickFirstResult().
                SetNumberOfInstances("5").
                ChooseOperatingSystem("Free").
                ChooseMachineClass("Regular").
                ChooseMachineSeries("N1").
                ChooseMachineType("vCPUs: 8, RAM: 30GB").
                ChooseGPU("NVIDIA Tesla P100", "1").
                ChooseLocalSSD("2x375 GB").
                ChooseDataCenterLocation("Frankfurt (europe-west3)").
                AddToEstimate();
            string price= GoogleUtilities.GetPrice();
            DriverUtilities.CreateNewTab();
            DriverUtilities.ChangeTabByNumber(1);
            YopMailUtilities.OpenYopMail().CreateRandomAcc();
            DriverUtilities.ChangeTabByNumber(0);
            GoogleUtilities.EnterIframe();
            GoogleUtilities.SendPriceToMail(CreateAccPage._addressee);
            DriverUtilities.ChangeTabByNumber(1);
            YopMailUtilities.WaitForMessage();
            Console.WriteLine(YopMailUtilities.IsPriceCorrect(price));       
        }
    }
}
