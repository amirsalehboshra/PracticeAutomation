using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AventStack.ExtentReports.Reporter.Configuration;

namespace PracticeAutomation.Utility
{
   public class ReportingManager
    {
        static AventStack.ExtentReports.ExtentReports extentReports;
        private static string solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        private static string reportFile = Path.Combine(solutionDir, "../", "Files", "TestReports", "ExtentReport.html");
        private static string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFile);

        private ReportingManager()
        {

        }

        public static AventStack.ExtentReports.ExtentReports GetInstance()
        {
            if (extentReports == null)
                CreateInstance();
            return extentReports;
        }

        public static AventStack.ExtentReports.ExtentReports CreateInstance()
        {

            var htmlReporter = new ExtentHtmlReporter(reportPath);
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


    }
}
