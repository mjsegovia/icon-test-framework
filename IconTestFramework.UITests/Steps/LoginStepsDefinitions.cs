using FluentAssertions;
using IconTestFramework.UIAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Steps
{
    [Binding]
    public class LoginStepsDefinitions :BaseSteps
    {
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;

        public LoginStepsDefinitions(IWebDriver driver, ScenarioContext context) : base(driver, context)
        {
            _driver = driver;
            _loginPage = new LoginPage(driver);
            _dashboardPage = new DashboardPage(driver);
        }

        [Given(@"I am on the Evernote login page")]
        public void GivenIAmOnTheEvernoteLoginPage()
        {
            _loginPage.GoTo();
            if (_loginPage.IsAt() == false)
                throw new ElementNotVisibleException("The Login Page Did Not Load");
        }

        [When(@"I log in into my Evernote account with the credentials")]
        public void WhenILogInIntoMyEvernoteAccount(Table table)
        {
            // Extract username and password from the Table
            var credentials = table.Rows[0];  
            string username = credentials["username"];
            string password = credentials["password"];

            _loginPage.UserLogIn(username, password);

            if (!_dashboardPage.IsAt()) 
                throw new NotFoundException("The user could not Login");
        }

        [When(@"I enter a valid email '(.*)'")]
        [When(@"I enter an invalid email '(.*)'")]
        public void WhenIEnterAnEmail(string email)
        {
           _loginPage.InsertUsername(email);
           _loginPage.ClickContinueBtn();
        }

        [When(@"I enter a valid password '(.*)'")]
        [When(@"I enter an invalid password '(.*)'")]
        public void WhenIEnterAPassword(string password)
        {
            _loginPage.InsertPassword(password);
            _loginPage.ClickContinueBtn();
        }

        [When(@"I click on the continue button")]
        public void WhenIClickOnTheContinueButton()
        {
            _loginPage.ClickContinueBtn();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            var accountMenu = _dashboardPage.IsUserAccountMenuDisplayed();
            accountMenu.Should().BeTrue("because the user should be logged in successfully.");
        }

        [Then(@"I should see the user dashboard")]
        public void ThenIShouldSeeTheUserDashboard()
        {
            bool isInDashboard = _dashboardPage.IsAt();
            isInDashboard.Should().BeTrue("because the user dashboard should be visible after login.");
        }

        [Then(@"I should see an error message '(.*)'")]
        public void ThenIShouldSeeAnErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = _loginPage.GetErrorCredentialsMsg();
            actualErrorMessage.Should().Be(expectedErrorMessage, "because the expected error message should match the actual one.");
        }

        

    }
}
