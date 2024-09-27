using OpenQA.Selenium;

namespace IconTestFramework.UIAutomation.PageObjects
{
    public class DashboardPage : BasePage
    {
        private readonly By _userAccountMenuLocator = By.Id("qa-USER_PORTRAIT");
        private readonly By _titleTxtInputLocator = By.XPath("//textarea[@placeholder ='Title']");
        private readonly By _noteTxtInputLocator = By.Id("en-note");
        private readonly By _createNoteBtnLocator = By.XPath("//button[@aria-label='New Note']");
        private readonly By _signOutLinkLocator = By.Id("qa-ACCOUNT_DROPDOWN_LOGOUT");
        private readonly By _sideBarNoteTitleLocator = By.XPath("//*[contains(@id, '_qa-NOTES_SIDEBAR_NOTE_TITLE')]");

        private IWebElement UserAccountMenu => _driver.FindElement(_userAccountMenuLocator);
        private IWebElement TitleTxtInput => _driver.FindElement(_titleTxtInputLocator);
        private IWebElement NoteTxtInput => _driver.FindElement(_noteTxtInputLocator);
        private IWebElement CreateNoteBtn => _driver.FindElement(_createNoteBtnLocator);
        private IWebElement SignOutLink => _driver.FindElement(_signOutLinkLocator);
        private IWebElement SideBarNoteTitle => _driver.FindElement(_sideBarNoteTitleLocator);

        public DashboardPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsUserAccountMenuDisplayed() => _helper.WaitForElementToBeVisible(_userAccountMenuLocator);

        public void OpenAnExistingNote(string title) => SideBarNoteTitle.Click();

        public string GetNoteTitle() => TitleTxtInput.Text;

        public string GetNoteDescription() => NoteTxtInput.Text;

        public override bool IsAt() => IsUserAccountMenuDisplayed();

        public void ClickCreateNoteBtn()
        {
            _helper.WaitForElementToBeVisible(_createNoteBtnLocator);
            CreateNoteBtn.Click();
        }

        public void CreateNote(string title,  string description)
        {
            _helper.WaitForElementToBeVisible(_titleTxtInputLocator);
            TitleTxtInput.SendKeys(title);
            NoteTxtInput.SendKeys(description);
        }

        public void Logout()
        {
            UserAccountMenu.Click();
            _helper.WaitForElementToBeVisible(_signOutLinkLocator);
            SignOutLink.Click();
        }
    }
}
