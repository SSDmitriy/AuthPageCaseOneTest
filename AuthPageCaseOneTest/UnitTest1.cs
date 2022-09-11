//автотест 11-09-22
//авторизаци€ на test.case.one и проверки, что:
//  открыт раздел "—обыти€"
//  им€ залогиненого пользовател€ "userFirstName userLastName"

using NUnit.Framework;
using OpenQA.Selenium;
using AuthPageCaseOneTest.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AuthPageCaseOneTest
{
    public class Tests
    {

        private IWebDriver _webDriver;
               

        // ожидаемые результаты
        private const string _expectedPageTitle = "—обыти€";
        private const string _expectedLoggedUser = "userFirstName userLastName";

        //действи€ перед тестом (инициализации)
        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl(Helpers.Base.BASE_URL);
            _webDriver.Manage().Window.Maximize();
        }

        //—ам тест - «алогинитьс€ и проверить, что отображаетс€ название раздела "—обыти€"
        [Test]
        public void Test01()
        {
            var authPage = new AuthPageObject(_webDriver);
            authPage.InputLogin();
            authPage.InputPassword();
            authPage.SubmitButton();

            var eventsPage = new EventsPageObject(_webDriver);

            //ожидание загрузки нужных элементов (чтобы не использовать топорный Thread.Sleep()
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(_webDriver => _webDriver.FindElement(eventsPage.pageTitle));
            wait.Until(_webDriver => _webDriver.FindElement(eventsPage.userOnPage));

            //получение и ассерт фактических результатов, отображаемых на странице
            string actualPageTitle = eventsPage.GetTitle();
            Assert.AreEqual(_expectedPageTitle, actualPageTitle, "Ќеправильное название раздела: "
                                                                    + _expectedPageTitle);

            string actualLoggedUser = eventsPage.GetLoggedUser();
            Assert.AreEqual(_expectedLoggedUser, actualLoggedUser, "Ќеправильное им€ залогиненого пользовател€: "
                                                                        + _expectedLoggedUser);

        }


        //действи€ после тесов (закрыть браузер)
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}