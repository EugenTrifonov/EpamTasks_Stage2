using OpenQA.Selenium;
using Task5.Base;

namespace Task5.Utilities
{
    public static class DriverUtilities
    {
        private static IWebDriver _driver = Driver.GetInstance();

        public static void CreateNewTab()
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            System.Console.WriteLine(_driver.WindowHandles.Count);
        }

        public static void ChangeTabByNumber(int number)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[number]);
        }

    }
}
