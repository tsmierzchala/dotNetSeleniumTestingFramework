using dotNetSeleniumTestingFramework.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace dotNetSeleniumTestingFramework.SetupTeardown
{
    [Binding]
    public class BeforeScenario
    {
        [BeforeScenario(Order = 1)]
        public static void SetUp()
        {
            string settingsJson = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestSettings.json"));
            TestSettings settings = JsonConvert.DeserializeObject<TestSettings>(settingsJson);
            Driver.Initialize(settings);
        }
    }
}
