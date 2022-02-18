using dotNetSeleniumTestingFramework.Helpers.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace dotNetSeleniumTestingFramework.Helpers
{
    public class TestSettings
    {
        [JsonProperty("DownloadFolder", Required = Required.Always)]
        private readonly string downloadFolder;

        [JsonIgnore]
        public string DownloadFolder
        {
            get
            {
                string path = downloadFolder;
                if (!Path.IsPathRooted(path)) {
                    path = AppDomain.CurrentDomain.BaseDirectory + path;
                }

                var dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists) {
                    dirInfo.Create();
                }

                return dirInfo.FullName;
            }
        }

        [JsonProperty("Browser", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public readonly BrowserType CurrentBrowser;

        [JsonProperty("RunAsHeadless", Required = Required.Default)]
        public bool RunAsHeadless { get; set; } = false;

        [JsonProperty("ImplicitWaitTimeout", Required = Required.Always)]
        private static int implicitWaitTimeout;

        [JsonIgnore]
        public static TimeSpan DefaultImplicitWaitTimeout => TimeSpan.FromSeconds(implicitWaitTimeout);
    }
}
