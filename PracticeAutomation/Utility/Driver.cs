using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PracticeAutomation.Utility
{
    class Driver
    {
        private static IWebDriver driver;


        private Driver()
        {

        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
                InitializeDriver();
            return driver;
        }


        public static IWebDriver InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }

    }
}
