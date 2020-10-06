using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace PracticeAutomation.Utility
{
    public class ReportingManager
    {
        static AventStack.ExtentReports.ExtentReports extentReports;
        [ThreadStatic]
        static ExtentTest extentTests;

        public static ExtentTest extentTest => extentTests ?? throw new NullReferenceException("extentTest is null.");
        public static AventStack.ExtentReports.ExtentReports extentReport => extentReports ?? throw new NullReferenceException("extentTest is null.");


        private static string solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        private static string reportFile = Path.Combine(solutionDir, "../", "Files", "TestReports", "ExtentReport.html");
        private static string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFile);

        private ReportingManager()
        {

        }

        public static AventStack.ExtentReports.ExtentReports GetReportInstance()
        {
            if (extentReports == null)
                CreateReportInstance();
            return extentReports;
        }
        public static AventStack.ExtentReports.ExtentReports CreateReportInstance()
        {
            var htmlReporter = new ExtentV3HtmlReporter(reportPath);
            htmlReporter.Config.CSS = "css-string";
            htmlReporter.Config.DocumentTitle = "Practice Automation Report";
            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.Encoding = "utf-8";
            //htmlReporter.Config.JS = "js-string";
            htmlReporter.Config.ReportName = "Practice Automation Report";
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(htmlReporter);

            return extentReports;
        }
        public static ExtentTest GetTestInstance()
        {
            if (extentTests == null)
                CreateTestInstance();
            return extentTests;
        }
        public static ExtentTest CreateTestInstance()
        {
            extentTests = extentReports.CreateTest(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.FullName);
            return extentTests;
        }



    }
}
