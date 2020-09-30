
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PracticeAutomation.Pages;
using PracticeAutomation.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using PracticeAutomation.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter.Configuration;

namespace Practice.Test
{
    class BaseTest
    {
        protected IWebDriver driver;

        protected HomePage _homePage;
        protected _loginPage _loginPage;
        protected AccountCreationPage _accountCreationPage;
        protected MyAccountPage _myAccountPage;
        protected ProductPage _productPage;
        protected OrderPage _orderPage;
        protected MenuPage _menuPage;
        protected ProductsPage _productsPage;

        protected static AventStack.ExtentReports.ExtentReports extentReports;
        protected static ExtentTest extentTest;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extentReports = ReportingManager.GetInstance();
        }


        [SetUp]
        public void SetUp()
        {
            // Start Driver
            string URL = Helper.GetConfigValueByKey("DevelopmentURL");
            // driver = Driver.GetDriver();

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(URL);

            //Start Report
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.FullName);

        }



        [TearDown]
        public void TearDown()
        {
            //Start test report
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = new System.Diagnostics.StackTrace().ToString();

            if (status == TestStatus.Failed)
            {
                extentTest.Log(Status.Fail, status + errorMessage);
                //To take screenshot
                var ScreenshotName = TestContext.CurrentContext.Test.FullName;
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
                var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
                var screenshotFile = Path.Combine(solutionDir, "../", "Files", "Screenshots", ScreenshotName + ".png");
                var screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, screenshotFile);
                //Save screenshot
                file.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                //Log screenshot
                extentTest.Log(Status.Debug, "Snapshot below: " + extentTest.AddScreenCaptureFromPath(screenshotPath));
            }
            else if (status == TestStatus.Passed)
                extentTest.Log(Status.Pass, "Test Passed");
            else if (status == TestStatus.Warning)
                extentTest.Log(Status.Warning, "Warning");
            else if (status == TestStatus.Skipped)
                extentTest.Log(Status.Skip, "Skipped");
            //End test report





            //Close Driver
            driver.Close();
            driver.Quit();
            driver.Dispose();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //End Report
            extentReports.Flush();
        }


    }
}
