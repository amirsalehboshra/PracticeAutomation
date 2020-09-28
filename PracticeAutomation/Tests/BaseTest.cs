
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

namespace Practice.Test
{
    class BaseTest
    {
        protected HomePage _homePage;
        protected _loginPage _loginPage;
        protected AccountCreationPage _accountCreationPage;
        protected MyAccountPage _myAccountPage;
        protected IWebDriver driver;

        //[SetUp]
        //public void IntializePages()
        //{


        //    _homePage = new HomePage(driver);
        //    _loginPage = new LoginPage(driver);
        //    _accountCreationPage = new AccountCreationPage(driver);
        //    _myAccountPage = new MyAccountPage(driver);

        //}

        //public AventStack.ExtentReports.ExtentReports Reporter;
        //public ExtentTest test;

        //static String reportLocation = @"D:\Projects\PracticeAutomation\PracticeAutomation\Files\TestReports\";
        //static String imageLocation = @"D:\Projects\PracticeAutomation\PracticeAutomation\Files\Screenshots\";

        public string Server { get; set; }




        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            //string projectPath = new Uri(actualPath).LocalPath;

            //ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(reportLocation + "test.html");
            //Reporter = new AventStack.ExtentReports.ExtentReports();

            //Reporter.AttachReporter(extentHtmlReporter);
            //Reporter.AddTestRunnerLogs("hhh");
           
            //Reporter.AddSystemInfo("Host Name", "A");
            //Reporter.AddSystemInfo("Environment", "QA");
            //Reporter.AddSystemInfo("User Name", "A");
           
        }


        [SetUp]
        public void SetUp()
        {
          
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string URL = Helper.GetConfigValueByKey("DevelopmentURL");
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(URL);

        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }


    }
}
