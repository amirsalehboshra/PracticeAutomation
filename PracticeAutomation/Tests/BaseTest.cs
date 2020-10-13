using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;
using System.IO;

namespace Practice.Test
{
    public abstract class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Helper.IntitializeDateTimeVariable();
            ReportingManager.GetReportInstance();
        }

        [SetUp]
        public void SetUp()
        {
            Configure.SetConfig();
            Logger.SetLogger();
            Driver.Init();
            Pages.Init();

            string URL = Configure.Config.Environment.Url;
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

                ReportingManager.ExtentTest.Fail(status + errorMessage);
                //To take screenshot
                Driver.CaptureScreenshot(TestContext.CurrentContext.Test.FullName);
                //Log screenshot
                var screenshotPath = Path.Combine(Helper.ScreenshotPath, Helper.GetDateTimeVariable() + TestContext.CurrentContext.Test.FullName + ".png");

                ReportingManager.ExtentTest.Debug("Snapshot below: " + ReportingManager.ExtentTest.AddScreenCaptureFromPath(screenshotPath));
            }
            else if (status == TestStatus.Passed)
                ReportingManager.ExtentTest.Pass("Test Passed");
            else if (status == TestStatus.Warning)
                ReportingManager.ExtentTest.Warning("Warning");
            else if (status == TestStatus.Skipped)
                ReportingManager.ExtentTest.Skip("Skipped");
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
            ReportingManager.ExtentReport.Flush();
        }

    }
}
