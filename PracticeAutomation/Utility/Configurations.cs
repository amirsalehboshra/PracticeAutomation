using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeAutomation.Utility
{

    public class Configure

    {
        public static Configurations Config => _configuration ?? throw new NullReferenceException("Config is null. Call FW.SetConfig() first.");

        private static Configurations _configuration;

        public static void SetConfig()
        {
            if (_configuration == null)
            {
                string jsonStr = File.ReadAllText(Helper.WORKSPACE_DIRECTORY + "/appsettings.json");
                _configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Configurations>(jsonStr);
            }
        }


    }

    public class Configurations
    {
        public DriverSettings Driver { get; set; }
        public EnvironmentSettings Environment { get; set; }

    }
    public class DriverSettings
    {
        public string Browser { get; set; }
    }

    public class EnvironmentSettings
    {
        public string Url { get; set; }
    }

}
