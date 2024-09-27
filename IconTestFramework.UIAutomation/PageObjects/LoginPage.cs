using IconTestFramework.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTestFramework.UIAutomation.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameInputLocator = By.Id("email");
        private readonly By _continueBtnLocator = By.XPath("//*[text()='Continue']/parent::button");
        private readonly By _passwordInputLocator = By.XPath("//input[@placeholder='Password']");
        private readonly By _errorCredentialsMsgLocator = By.XPath("//span[contains(@class, 'text-secondary-red-400')]");
        private readonly By _signInTxt = By.XPath("//h1[text()='Sign in']");
        private readonly string _loginUrl;

        private IWebElement UserInput => _driver.FindElement(_usernameInputLocator);
        private IWebElement ContinueBtn => _driver.FindElement(_continueBtnLocator);
        private IWebElement PasswordInput => _driver.FindElement(_passwordInputLocator);
        private IWebElement ErrorCredentialsMsg => _driver.FindElement(_errorCredentialsMsgLocator);
        private IWebElement SignInTxt => _driver.FindElement(_signInTxt);

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _loginUrl = Configurator.BaseUrl + Configurator.LoginUrl;
        }

        //Element Actions
        public void InsertUsername(string username)
        {
            _helper.WaitForElementToBeVisible(_usernameInputLocator);
            UserInput.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            _helper.WaitForElementToBeVisible(_passwordInputLocator);
            PasswordInput.SendKeys(password);
        }

        public void ClickContinueBtn()
        {
            _helper.WaitForElementToBeVisible(_continueBtnLocator);
            ContinueBtn.Click();
        }

        public string GetErrorCredentialsMsg()
        {
            _helper.WaitForElementToBeVisible(_errorCredentialsMsgLocator);
            return ErrorCredentialsMsg.Text;
        }

        public override bool IsAt() => _helper.WaitForElementToBeVisible(_signInTxt);        

        public void UserLogIn(string username, string password)
        {
            InsertUsername(username);
            InsertPassword(password);
        }

        public void GoTo()
        {
            _driver.Url = _loginUrl;
            _driver.Navigate();
        }
    }
}
