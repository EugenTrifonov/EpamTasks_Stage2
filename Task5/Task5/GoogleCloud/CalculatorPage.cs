using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Task5.Base;

namespace Task5.GoogleCloud
{
    public class CalculatorPage : BasePage
    {
        private readonly By _numberOfInstances = By.XPath("//label[contains(text(),'Number')]//..//input");
        private readonly By _operatingSystemsContainer = By.XPath("//md-input-container//label[contains(text(),'Operating System / Software')]/..//md-select");
        private readonly By _machineClassContainer = By.XPath("//md-input-container//label[contains(text(),'Machine Class')]/..//md-select");
        private readonly By _machineTypeContainer = By.XPath("//md-input-container//label[contains(text(),'Machine type')]/..//md-select");
        private readonly By _machineSeriesContainer = By.XPath("//md-input-container//label[contains(text(),'Series')]/..//md-select");
        private readonly By _addGPUsCheckBox = By.XPath("//div[contains(text(),'Add GPUs')]/..");
        private readonly By _gputypeContainer = By.XPath("//md-select[@placeholder='GPU type']");
        private readonly By _gpuamountContainer = By.XPath("//md-select[@placeholder='Number of GPUs']");
        private readonly By _localSSDContainer = By.XPath("//md-select[@placeholder='Local SSD']");
        private readonly By _datacenterLocationContainer = By.XPath("//md-select[@placeholder='Datacenter location']");
        private readonly By _addToEstimateButton = By.XPath("//button[@aria-label='Add to Estimate']");
        private readonly By _emailEstimateButton = By.XPath("//md-card-content[@id='resultBlock']//*[@id='email_quote']");
        private readonly By _emailField = By.XPath("//input[@type='email']");
        private readonly By _sendMailButton = By.XPath("//button[@aria-label='Send Email']");
        private readonly By _priceLocator = By.XPath("//b[contains(@class,'binding')]");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CalculatorPage(IWebDriver driver) : base(driver) 
        {
            _driver.FindElement(By.XPath("//title[contains(text(),'Calculator')]"));
        }

        static CalculatorPage()
        {
            IWebElement iframe = _driver.FindElement(By.XPath("*//iframe"));
            _driver.SwitchTo().Frame(iframe);
            iframe = _driver.FindElement(By.XPath("//iframe[@id='myFrame']"));
            _driver.SwitchTo().Frame(iframe);
        }

        public CalculatorPage SetNumberOfInstances(string number)
        {
            try
            {
                _driver.FindElement(_numberOfInstances).SendKeys(number);

                _logger.Info("SetNumberOfInstances:SUCESS");
            }
            catch
            {
                _logger.Error("SetNumberOfInstances:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseOperatingSystem(string system)
        {
            try
            {
                _driver.FindElement(_operatingSystemsContainer).Click();
                Driver.FindElementByXpath($"//md-content//md-option//div[contains(text(),'{system}')]").Click();

                _logger.Info("ChooseOperatingSystem:SUCESS");
            }
            catch
            {
                _logger.Error("ChooseOperatingSystem:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseMachineClass(string machineClass)
        {
            try
            {
                _driver.FindElement(_machineClassContainer).Click();
                _driver.FindElements(By.XPath($"//md-content//md-option//div[contains(text(),'{machineClass}')]"))[1].Click();

                _logger.Info("ChooseMachineClass:SUCESS");
            }
            catch
            {
                _logger.Error("ChooseMachineClass:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseMachineSeries(string machineSeries)
        {
            try
            {
                _driver.FindElement(_machineSeriesContainer).Click();
                _driver.FindElement(By.XPath($"//md-content//md-option//div[contains(text(),'{machineSeries}')]")).Click();

                _logger.Info("ChooseMachineSeries:SUCESS");
            }
            catch
            {
                _logger.Error("ChooseMachineSeries:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseMachineType(string machineType)
        {
            try
            {
                _driver.FindElement(_machineTypeContainer).Click();

                IWebElement Element = _driver.FindElement(By.XPath($"//md-content//md-option//div[contains(text(),'{machineType}')]"));

                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript("arguments[0].click();", Element);

                _logger.Info("ChooseMachineType:SUCESS");
            }
            catch 
            {
                _logger.Error("ChooseMachineType:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseGPU(string type, string amount)
        {
            try
            {
                _driver.FindElement(_addGPUsCheckBox).Click();
                _driver.FindElement(_gputypeContainer).Click();

                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;

                IWebElement Element = _driver.FindElement(By.XPath($"//md-option//div[contains(text(),'{type}')]"));
                executor.ExecuteScript("arguments[0].click();", Element);


                Driver.WaitUntilElementIsVissibleAndActive(_gpuamountContainer);
                _driver.FindElement(_gpuamountContainer).Click();
                CalculatorPage.ScrollPage();


                Element = _driver.FindElement(By.XPath($"//md-option[contains(@ng-repeat,'GpuNumbers')]//div[contains(text(),'{amount}')]"));
                executor.ExecuteScript("arguments[0].click();", Element);

                _logger.Info("ChooseGPU:SUCESS");
            }
            catch 
            {
                _logger.Error("ChooseGPU:ERROR");
            }

            return this;
        }

        public CalculatorPage ChooseLocalSSD(string ssd)
        {
            try
            {
                _driver.FindElement(_localSSDContainer).Click();

                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;

                IWebElement Element = _driver.FindElement(By.XPath($"//md-option[contains(@ng-repeat,'Ssd')]//div[contains(text(),'{ssd}')]"));
                executor.ExecuteScript("arguments[0].click();", Element);

                _logger.Info("ChooseLocalSSD:SUCESS");
            }
            catch 
            {
                _logger.Error("ChooseLocalSSD:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage ChooseDataCenterLocation(string location)
        {
            try
            {
                _driver.FindElement(_datacenterLocationContainer).Click();

                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;

                IWebElement Element = _driver.FindElement(By.XPath($"//md-option[contains(@ng-repeat,'inputRegionText.computeServer')]//div[contains(text(),'{location}')]"));
                executor.ExecuteScript("arguments[0].click();", Element);

                _logger.Info("ChooseDataCenterLocation:SUCESS");
            }
            catch 
            {
                _logger.Error("ChooseDataCenterLocation:ERROR");
            }

            CalculatorPage.ScrollPage();

            return this;
        }

        public CalculatorPage AddToEstimate()
        {
            _driver.FindElement(_addToEstimateButton).Click();

            return this;
        }

        public CalculatorPage EmailEstimate(string email)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            IWebElement Element = _driver.FindElement(_emailEstimateButton);
            executor.ExecuteScript("arguments[0].click();", Element);

            _driver.FindElement(_emailField).SendKeys(email);
            _driver.FindElement(_sendMailButton).Click();

            return this;
        }

        public string GetPrice()
        {
            string price = _driver.FindElement(_priceLocator).Text;

            return price;
        }

        private static void ScrollPage()
        {
            IWebElement firstCommand = _driver.FindElement(By.TagName("body"));
            firstCommand.SendKeys(Keys.ArrowDown);
        }
    }
}
