using System;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Steps
{
    [Binding]
    public class UserAPI_ListUsersSteps
    {
        [Given(@"the API endpoint to list users is ""(.*)""")]
        public void GivenTheAPIEndpointToListUsersIs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the API is up and running")]
        public void GivenTheAPIIsUpAndRunning()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have a valid API token")]
        public void GivenIHaveAValidAPIToken()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send a GET request to ""(.*)"" with the query parameter '(.*)' set to (.*)")]
        public void WhenISendAGETRequestToWithTheQueryParameterSetTo(string p0, string p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I send a GET request to ""(.*)"" with the query parameter '(.*)' set to '(.*)'")]
        public void WhenISendAGETRequestToWithTheQueryParameterSetTo(string p0, string p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The page number returned matches with the one specified in the URL")]
        public void ThenThePageNumberReturnedMatchesWithTheOneSpecifiedInTheURL()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the response should contain a list of users of (.*)")]
        public void ThenTheResponseShouldContainAListOfUsersOf(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the list should contain users for page (.*)")]
        public void ThenTheListShouldContainUsersForPage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The page number returned matches with the one spec ified in the URL")]
        public void ThenThePageNumberReturnedMatchesWithTheOneSpecIfiedInTheURL()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The response should not contain users")]
        public void ThenTheResponseShouldNotContainUsers()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
