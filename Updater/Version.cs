using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    public class Version
    {
        public Version() { }

        public string AppVersion { get; set; }
        public string Url { get; set; }
    }
    public class AppSettingConfig
    {
        public static Version ReadAppSetting()
        {
            try
            {
                var jsonData = File.ReadAllText("Version.json");
                var version = JsonConvert.DeserializeObject<Version>(jsonData);
                return version;
            }
            catch (Exception)
            {
                return new Version();
            }
        }

        public static void WriteAppSetting(Version version)
        {
            var jsonData = JsonConvert.SerializeObject(version, Formatting.Indented);
            File.WriteAllText("Version.json", jsonData);
        }
    }
}
