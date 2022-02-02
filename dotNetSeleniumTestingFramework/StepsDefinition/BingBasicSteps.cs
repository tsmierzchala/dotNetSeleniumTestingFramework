using dotNetSeleniumTestingFramework.Helpers;
using dotNetSeleniumTestingFramework.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace dotNetSeleniumTestingFramework.StepsDefinition
{
    [Binding]
    public class BingBasicSteps
    {
        [Given(@"User is on bing\.com webpage")]
        public void GivenUserIsOnBing_ComWebpage()
        {
            Driver.Instance.Url = "https://www.bing.com";
            var bingPage = new BingHomePage();
        }

        [When(@"User searches for ""([^""]*)""")]
        public void WhenUserSearchesFor(string p0)
        {
            var bingPage = new BingHomePage();
            bingPage.SearchForText(p0);
        }

        [Then(@"First three results contains ""([^""]*)""")]
        public void ThenFirstThreeResultsContains(string expectedText)
        {
            var resultPage = new BingResultPage();
            List<string> firstThreeResults = resultPage.GetFirstThreeResults();
            firstThreeResults.ForEach(e => e.Contains("pit"));
        }

    }
}
