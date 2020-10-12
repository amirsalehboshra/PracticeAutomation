using NUnit.Framework;
using System;
using System.IO;

namespace PracticeAutomation.Utility
{
    public class Logger
    {
        [ThreadStatic]
        private static Logger _logger;
        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");
     
        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testName = TestContext.CurrentContext.Test.FullName;

                var logsPath = Path.Combine(Helper.WORKSPACE_DIRECTORY , "Files", "Logs");

                _logger = new Logger(testName, logsPath + "/" + testName + ".txt");
            }
        }
        private static object _setLoggerLock = new object();
        private readonly string _filepath;
        public Logger(string testName, string filepath)
        {
            _filepath = filepath;

            using (var log = File.CreateText(_filepath))
            {
                log.WriteLine($"Starting timestamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testName}");
            }
        }


        public void Info(string message)
        {
            WriteLine($"[INFO]: {message}");
        }
        public void Step(string message)
        {
            WriteLineWithTime($"    [STEP]: {message}");
        }
        public void Error(string message)
        {
            WriteLine($"[ERROR]: {message}");
        }
        private void WriteLineWithTime(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.WriteLine(text + "  " + DateTime.Now.ToString());
            }
        }
        private void WriteLine(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.WriteLine(text);
            }
        }

    }

}

