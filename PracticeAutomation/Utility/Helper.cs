using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace PracticeAutomation.Utility
{
    static public class Helper
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../");

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
        public static string GetDateTimeVariable()
        {
            string DateTimeTicks = DateTime.Now.Ticks.ToString();
            string DateTimeVariable = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            return DateTimeVariable;
        }
        public static string GetRandomMail()
        {
            string email = "amir+" + GetDateTimeVariable() + "@gmail.com";
            return email;
        }
        public static string GetScreenshotPath()
        {
            var screenshotPath = Path.Combine(WORKSPACE_DIRECTORY, "Files", "Screenshots", TestContext.CurrentContext.Test.FullName + ".png");
            return screenshotPath;
        }
    }
}
