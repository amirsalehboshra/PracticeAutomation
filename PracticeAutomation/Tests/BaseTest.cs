
using NUnit.Framework;
using PracticeAutomation.PagesObjects;
using System;
using System.IO;
using PracticeAutomation.Utility;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Practice.Test
{
    public abstract class BaseTest
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
             ReportingManager.GetReportInstance();
        }

        [SetUp]
        public void SetUp()
        {
            Logger.SetLogger();
            Driver.Init();
            Pages.Init();

            string URL = Helper.GetConfigValueByKey("URL");
            Driver.Goto(URL);

            ReportingManager.CreateTestInstance();
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
                Logger.Log.Error(errorMessage);
                Logger.Log.Error(stackTrace);

                ReportingManager.extentTest.Log(Status.Error, status + errorMessage);
                //To take screenshot
                Driver.CaptureScreenshot(TestContext.CurrentContext.Test.FullName);
                //Log screenshot
                ReportingManager.extentTest.Log(Status.Debug, "Snapshot below: " + ReportingManager.extentTest.AddScreenCaptureFromPath(Helper.GetScreenshotPath()));
            }
            else if (status == TestStatus.Passed)
                ReportingManager.extentTest.Log(Status.Pass, "Test Passed");
            else if (status == TestStatus.Warning)
                ReportingManager.extentTest.Log(Status.Warning, "Warning");
            else if (status == TestStatus.Skipped)
                ReportingManager.extentTest.Log(Status.Skip, "Skipped");
            //End test report


            Logger.Log.Info(TestContext.CurrentContext.Result.Outcome.Status.ToString());


            //Close Driver
            Driver.Current.Close();
            Driver.Current.Quit();
            Driver.Current.Dispose();
            Logger.Log.Info("Browser closed");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //End Report
            ReportingManager.extentReport.Flush();
        }


    }
}
