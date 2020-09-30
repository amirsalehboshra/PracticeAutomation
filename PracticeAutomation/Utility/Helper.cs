using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using PracticeAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Text;

namespace PracticeAutomation.Utility
{
    static public class Helper
    {
        static public string GetConfigValueByKey(string key)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var value = configuration.GetSection("ConfigurationVariables").GetSection(key).Value;
            return value;
        }
        static public int GetRandomNumber(int Min, int Max)
        {
            var random = new Random();
            var value = random.Next(Min, Max);
            return value;
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
    }
}
