using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace PracticeAutomation.Utility
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Debug.WriteLine(url);
            Current.Navigate().GoToUrl(url);
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
        }


        //private static IWebDriver driver;


        //private Driver()
        //{

        //}

        //public static IWebDriver GetDriver()
        //{
        //    if (driver == null)
        //        InitializeDriver();
        //    return driver;
        //}


        //public static IWebDriver InitializeDriver()
        //{
        //    driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        //    return driver;
        //}

    }
}
