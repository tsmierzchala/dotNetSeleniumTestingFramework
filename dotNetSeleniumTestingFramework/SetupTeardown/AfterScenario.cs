using dotNetSeleniumTestingFramework.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace dotNetSeleniumTestingFramework.SetupTeardown
{
    [Binding]
    public class AfterScenario
    {
        [AfterScenario(Order = 1000)]
        public static void TearDown() => Driver.Instance.Quit();
    }
}
