using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;

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

                ReportingManager.extentTest.Fail( status + errorMessage);
                //To take screenshot
                Driver.CaptureScreenshot(TestContext.CurrentContext.Test.FullName);
                //Log screenshot
                ReportingManager.extentTest.Debug( "Snapshot below: " + ReportingManager.extentTest.AddScreenCaptureFromPath(Helper.GetScreenshotPath()));
            }
            else if (status == TestStatus.Passed)
                ReportingManager.extentTest.Pass( "Test Passed");
            else if (status == TestStatus.Warning)
                ReportingManager.extentTest.Warning( "Warning");
            else if (status == TestStatus.Skipped)
                ReportingManager.extentTest.Skip( "Skipped");
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
