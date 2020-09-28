using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using PracticeAutomation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PracticeAutomation.Utility
{
    static public class Helper
    {
        static public string GetConfigValueByKey(string key) {

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var value = configuration.GetSection("ConfigurationVariables").GetSection(key).Value;
            return value;

        }
        static public int GetRandomNumber (int Min,int Max)
        {
            var random = new Random();
            var value = random.Next(Min, Max);
            return value;
        }

    }
}
