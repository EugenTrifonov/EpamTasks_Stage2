using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Task5.Base;
using Task5.GoogleCloud;
using Task5.Utilities;

namespace Tests
{
    public class BaseTest
    {
        protected readonly Configuration configuration = ConfigurationCreator.FullConfiguration();

        protected static IWebDriver _driver=Driver.GetInstance();

        [SetUp]
        public void Setup()
        {
            GoogleUtilities.StartUpBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                Screenshoter.MakeScreenshot(_driver);
            }

            Driver.CloseBrowser();
        }
    }
}