using dotNetSeleniumTestingFramework.Helpers.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace dotNetSeleniumTestingFramework.Helpers
{
    public class Driver
    {
        private static IWebDriver driver;
        private static string DownloadFolder;

        private static readonly string nullRefMsg = "Driver must be initialized before calling for its instance.";

        private Driver(TestSettings testSettings)
        {
            DownloadFolder = testSettings.DownloadFolder;
            BrowserType browserType = testSettings.CurrentBrowser;

            switch (browserType)
            {
                case BrowserType.Edge:
                    driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    break;

                case BrowserType.Firefox:
                    driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory);
                    break;

                case BrowserType.Chrome:
                default:
                    var chromeOptions = new ChromeOptions();
                    if (testSettings.RunAsHeadless)
                        chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-single-click-autofill");
                    chromeOptions.AddUserProfilePreference(("download.default_directory"), DownloadFolder);
                    driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions, TimeSpan.FromMinutes(10));
                    break;

            }

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        public static Driver Initialize(TestSettings settings) => new Driver(settings);


        public static IWebDriver Instance => driver ?? throw new NullReferenceException(nullRefMsg);
    }
}
