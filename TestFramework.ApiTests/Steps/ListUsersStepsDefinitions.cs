using FluentAssertions;
using IconTestFramework.ApiAutomation;
using IconTestFramework.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Steps
{
    [Binding]
    public class ListUsersSteps
    {
        private ScenarioContext _scenarioContext;
        private HttpClientHelper _httpClient;

        public ListUsersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _httpClient = new HttpClientHelper();
        }

        [Given(@"the API endpoint to list users is '(.*)'")]
        public void GivenTheAPIEndpointToListUsersIs(string endPoint)
        {     
            _scenarioContext.Add("end_point", endPoint);
        }      
        
        [When(@"I send a GET request with the query parameter '(.*)' set to '(.*)'")]
        public async Task WhenISendAGETRequestToWithTheQueryParameterSetTo(string parameter, string page)
        {
            var endpoint = _scenarioContext.Get<string>("end_point");
            var queryParams = new Dictionary<string, string>
            {
                { parameter, page }
            };
            //Saving the current page value
            _scenarioContext.Add("page", page);

            //Sending Request
            var responseData = await _httpClient.GetTWithParamsAsync<UserResponse>(endpoint, queryParams);
            _scenarioContext.Add("response_data", responseData);
        }

        [Then(@"the response status should be '(.*)'")]
        public void ThenValidateResponseStatus(string responseStatus)
        {
            _httpClient.Response.ResponseStatus.ToString().Should().Be(responseStatus);
        }

        [Then(@"the response status code should be '(.*)'")]
        public void ThenTheResponseStatusCodeShouldBe(string statusCode)
        {
            _httpClient.Response.StatusCode.ToString().Should().Be(statusCode);
        }
        
        [Then(@"the page number returned matches with the one specified in the URL")]
        public void ThenThePageNumberReturnedMatchesWithTheOneSpecifiedInTheURL()
        {
            var responseData = _scenarioContext.Get<UserResponse>("response_data");
            var page = _scenarioContext.Get<string>("page");
            responseData.Page.ToString().Should().Be(page);

        }

        [Then(@"the list should contain the following user for page (.*)")]
        public void ThenTheResponseShouldContainAListOfUsersOf(int page, Table table)
        {
            var responseData = _scenarioContext.Get<UserResponse>("response_data");
            
            // Extract user details from the SpecFlow table
            var expectedFirstName = table.Rows[0]["first_name"];
            var expectedLastName = table.Rows[0]["last_name"];
            var expectedEmail = table.Rows[0]["email"];
            var expectedAvatar = table.Rows[0]["avatar"];

            // Find the user that matches the values from the table
            var matchingUser = responseData.Data.FirstOrDefault(user =>
                user.FirstName == expectedFirstName &&
                user.LastName == expectedLastName);

            // Assert that a matching user is found
            matchingUser.Should().NotBeNull
                ($"because a user with the first name '{expectedFirstName}', last name '{expectedLastName}', email '{expectedEmail}', and avatar '{expectedAvatar}' should exist");

            // Assert that the found user properties match the expected values
            matchingUser.FirstName.Should().Be(expectedFirstName);
            matchingUser.LastName.Should().Be(expectedLastName);
            matchingUser.Email.Should().Be(expectedEmail);
            matchingUser.Avatar.Should().Be(expectedAvatar);
        }

        [Then(@"the response should contain a list of users of (.*)")]
        public void ThenTheListShouldContainUsersForPage(int numUsers)
        {
            var responseData = _scenarioContext.Get<UserResponse>("response_data");

            responseData.PerPage.Should().Be(numUsers);
        }       
        
        [Then(@"the response should not contain users")]
        public void ThenTheResponseShouldNotContainUsers()
        {
            var responseData = _scenarioContext.Get<UserResponse>("response_data");
            var page = _scenarioContext.Get<string>("page");

            responseData.Data.Should().BeNullOrEmpty($"there is not user in the page '{page.Trim()}'");
        }
    }
}
