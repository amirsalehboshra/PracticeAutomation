using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace PracticeAutomation.Utility
{
    static public class Helper
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../");
        public static string ReportPath = Path.Combine(WORKSPACE_DIRECTORY, "Files", "TestReports", GetDateTimeVariable() + "TestReport.html");
        public static string ScreenshotPath = Path.Combine(WORKSPACE_DIRECTORY, "Files", "Screenshots");

        public static string LogsPath = Path.Combine(WORKSPACE_DIRECTORY, "Files", "Logs");

        public static string GetConfigValueByKey(string section, string key)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var value = configuration.GetSection(section).GetSection(key).Value;
            return value;
        }
        public static int GetRandomNumber(int Min, int Max)
        {
            var random = new Random();
            var value = random.Next(Min, Max);
            return value;
        }
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
        private static string DateTimeVariable;
        public static string GetDateTimeVariable()
        {
            if (DateTimeVariable == null)
                IntitializeDateTimeVariable();
            return DateTimeVariable;
        }
        public static void IntitializeDateTimeVariable()
        {
            string dateTimeVariable = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            DateTimeVariable = dateTimeVariable;
        }

        public static string GetRandomMail()
        {
            string email = "amir+" + GetDateTimeVariable() + "@gmail.com";
            return email;
        }

    }
}
