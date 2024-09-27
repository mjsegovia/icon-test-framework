using FluentAssertions;
using IconTestFramework.UIAutomation.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace IconTestFramework.UITests.Steps
{
    [Binding]
    public class NoteStepsDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly DashboardPage _dashboardPage;

        public NoteStepsDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _dashboardPage = new DashboardPage(driver);
        }

        [When(@"I click on New Note button")]
        public void WhenIClickOnNewNoteButton()
        {
            _dashboardPage.ClickCreateNoteBtn();
        }

        [When(@"I create a new note with the title '(.*)' and description '(.*)'")]
        public void WhenICreateANewNoteWithTheTitleAndDescription(string title, string description)
        {
            _dashboardPage.CreateNote(title, description);
        }
       
        [When(@"I sign out of my account")]
        public void WhenISignOutOfMyAccount()
        {
            _dashboardPage.Logout();
        }       

        [When(@"I open my note titled '(.*)'")]
        public void WhenIOpenMyNoteTitled(string title)
        {
            _dashboardPage.OpenAnExistingNote(title);
        }

        [Then(@"the title of my note should be '(.*)'")]
        public void ThenTheTitleOfMyNoteShouldBe(string expectedTitle)
        {
            _dashboardPage.GetNoteTitle().Trim().Should().Be(expectedTitle, "The note title should match the expected title.");            
        }

        [Then(@"the description of my note should be '(.*)'")]
        public void ThenTheDescriptionOfMyNoteShouldBe(string expectedDescription)
        {
            _dashboardPage.GetNoteDescription().Trim().Should().Be(expectedDescription, "The note description should match the expected description.");
        }
    }
}