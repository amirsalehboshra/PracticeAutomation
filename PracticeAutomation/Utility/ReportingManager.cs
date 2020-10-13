using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;

namespace PracticeAutomation.Utility
{
    public class ReportingManager
    {
        private static AventStack.ExtentReports.ExtentReports _extentReports;
        [ThreadStatic]
        private static ExtentTest _extentTests;

        public static ExtentTest ExtentTest => _extentTests ?? throw new NullReferenceException("_extentTest is null.");
        public static AventStack.ExtentReports.ExtentReports ExtentReport => _extentReports ?? throw new NullReferenceException("_extentTest is null.");

        private ReportingManager()
        {

        }

        public static AventStack.ExtentReports.ExtentReports GetReportInstance()
        {
            if (_extentReports == null)
                CreateReportInstance();
            return _extentReports;
        }
        public static AventStack.ExtentReports.ExtentReports CreateReportInstance()
        {
            var htmlReporter = new ExtentV3HtmlReporter(Helper.ReportPath);
            htmlReporter.Config.CSS = "css-string";
            htmlReporter.Config.DocumentTitle = "Practice Automation Report";
            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.Encoding = "utf-8";
            //htmlReporter.Config.JS = "js-string";
            htmlReporter.Config.ReportName = "Practice Automation Report";
            htmlReporter.Config.Theme = Theme.Standard;
            _extentReports = new AventStack.ExtentReports.ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            return _extentReports;
        }
        public static ExtentTest GetTestInstance()
        {
            if (_extentTests == null)
                CreateTestInstance();
            return _extentTests;
        }
        public static ExtentTest CreateTestInstance()
        {
            _extentTests = _extentReports.CreateTest(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.FullName);
            return _extentTests;
        }



    }
}
