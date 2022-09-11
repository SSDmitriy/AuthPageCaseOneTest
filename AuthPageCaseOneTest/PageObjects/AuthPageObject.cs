using OpenQA.Selenium;

namespace AuthPageCaseOneTest.PageObjects
{

    public class AuthPageObject
    {

        private IWebDriver _webDriver;

        // X-path элементов DOM-дерева
        private readonly By _loginInputField = By.XPath("//input[@name='login']");
        private readonly By _passwordInputField = By.XPath("//input[@name='password']");
        private readonly By _submitButton = By.XPath("//button[@type='submit']");
       
        public AuthPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void InputLogin()
        {
            _webDriver.FindElement(_loginInputField).SendKeys(Helpers.Secrets.LOGIN);
        }

        public void InputPassword()
        {
            _webDriver.FindElement(_passwordInputField).SendKeys(Helpers.Secrets.PASSWORD);
        }

        public void SubmitButton()
        {
            _webDriver.FindElement(_submitButton).Click();
        }
    }
}
