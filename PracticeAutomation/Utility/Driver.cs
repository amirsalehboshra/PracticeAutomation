using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticeAutomation.Utility
{
    public class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void Init()
        {
            string browser = Configure.Config.Driver.Browser;

            Logger.Log.Info("browser: " + browser);

            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    break;
                default:
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    break;
            }



        }

        #region Methods
        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Current.Navigate().GoToUrl(url);
            Logger.Log.Info("Environmrnt url: " + url);

        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void Click(IWebElement element)
        {
            element.Click();
            Logger.Log.Step("CLick: " + element.Text);
        }

        public static void CaptureScreenshot(string screenshotName)
        {
            Screenshot screenshotFile = ((ITakesScreenshot)Driver.Current).GetScreenshot();
            var screenshotPath = Path.Combine(Helper.ScreenshotPath, Helper.GetDateTimeVariable() + screenshotName + ".png");
            screenshotFile.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }
        #endregion
    }
}
