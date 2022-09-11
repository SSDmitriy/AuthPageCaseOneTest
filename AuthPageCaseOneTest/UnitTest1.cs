//автотест 11-09-22
//авторизация на test.case.one и проверки, что:
//  открыт раздел "События"
//  имя залогиненого пользователя "userFirstName userLastName"

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
        private const string _expectedPageTitle = "События";
        private const string _expectedLoggedUser = "userFirstName userLastName";

        //действия перед тестом (инициализации)
        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver(); //вынести в действия ПЕРЕД всеми
            _webDriver.Navigate().GoToUrl(Helpers.Base.BASE_URL);
            _webDriver.Manage().Window.Maximize();
        }

        //Сам тест - Залогиниться и проверить, что отображается название раздела "События"
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
            Assert.AreEqual(_expectedPageTitle, actualPageTitle, "Непрвильное название раздела: "
                                                                    + _expectedPageTitle);

            string actualLoggedUser = eventsPage.GetLoggedUser();
            Assert.AreEqual(_expectedLoggedUser, actualLoggedUser, "Неправильное имя залогиненого пользователя: "
                                                                        + _expectedLoggedUser);

        }


        //действия после тесов (закрыть браузер)
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}