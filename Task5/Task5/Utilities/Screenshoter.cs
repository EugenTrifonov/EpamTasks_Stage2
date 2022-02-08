using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;


namespace Task5.Utilities
{
    public class Screenshoter
    {
        private const string _savePath = "../../../../../Task5/Task5/Screenshots/";

        public static void MakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(CreateFilename(), ScreenshotImageFormat.Jpeg);
        }

        private static void CheckDirectory()
        {
            if (!Directory.Exists(_savePath))
            {
                Directory.CreateDirectory(_savePath);
            }
        }

        private static string CreateFilename()
        {
            string longdate = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string testName = TestContext.CurrentContext.Test.FullName;
            CheckDirectory();
            return _savePath + testName + longdate +".jpg";
        }
    }
}
