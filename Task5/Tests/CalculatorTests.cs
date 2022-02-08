using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.GoogleCloud;
using Task5.Utilities;
using Task5.YopMail;

namespace Tests
{

    public class CalculatorTests : BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public const string _calculatorName = "Google Cloud Platform Pricing Calculator";

        private static CalculatorPage _page;

        [SetUp]
        public void Setup()
        {
            _page = GoogleUtilities.StartUpBrowser().Search(_calculatorName).ClickFirstResult();
        }

        [Test]
        [Category("All")]
        [Category("Smoke tests")]
        public void SetNumberOfInstances() 
        {
            bool result=true;

            try
            {
                _page.SetNumberOfInstances(configuration.NumberOfInstances);
            }
            catch 
            {
                result = false;
            }

            Assert.IsTrue(result);
        }

        [Test]
        [Category("All")]
        [Category("Smoke tests")]
        public void SetMachineClass()
        {
            bool result = true;

            try
            {
                _page.ChooseMachineClass(configuration.MachineClass);
            }
            catch
            {
                result = false;
            }

            Assert.IsTrue(result);
        }

        [Test]
        [Category("All")]
        public void FullTest()
        {
                            _page.SetNumberOfInstances(configuration.NumberOfInstances).
                            ChooseOperatingSystem(configuration.OperatingSystem).
                            ChooseMachineClass(configuration.MachineClass).
                            ChooseMachineSeries(configuration.MachineSeries).
                            ChooseMachineType(configuration.MachineType).
                            ChooseGPU(configuration.GPU,configuration.GPUAmount).
                            ChooseLocalSSD(configuration.LocalSSD).
                            ChooseDataCenterLocation(configuration.DataCenterLocation).
                            AddToEstimate();

            string price = GoogleUtilities.GetPrice();

            DriverUtilities.CreateNewTab();
            DriverUtilities.ChangeTabByNumber(1);
            YopMailUtilities.OpenYopMail().CreateRandomAcc();
            DriverUtilities.ChangeTabByNumber(0);
            GoogleUtilities.EnterIframe();
            GoogleUtilities.SendPriceToMail(CreateAccPage._addressee);
            DriverUtilities.ChangeTabByNumber(1);
            YopMailUtilities.WaitForMessage();

           Assert.IsTrue(YopMailUtilities.IsPriceCorrect(price));
        }
    }
}
