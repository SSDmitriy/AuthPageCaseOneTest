using OpenQA.Selenium;

namespace AuthPageCaseOneTest.PageObjects
{
    internal class EventsPageObject
    {
        private IWebDriver _webDriver;
        
        //локатор заголовка раздела
        internal readonly By pageTitle = By.XPath("//span[@class='b-content-header-page-title']");

        //локатор залогиненого юзера
        internal readonly By userOnPage = By.XPath("//span[@class='b-sidebar-menu-text g-textoverflow']");

        public EventsPageObject(IWebDriver driver)
        {
            _webDriver = driver;
    
        }

        public string GetTitle()
        {
            string title = _webDriver.FindElement(pageTitle).Text;
            return title;
        }

        public string GetLoggedUser()
        {
            string loggedUser = _webDriver.FindElement(userOnPage).Text;
            return loggedUser;
        }
    }
}
