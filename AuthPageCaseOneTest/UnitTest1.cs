//�������� 11-09-22
//����������� �� test.case.one � ��������, ���:
//  ������ ������ "�������"
//  ��� ������������ ������������ "userFirstName userLastName"

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
               

        // ��������� ����������
        private const string _expectedPageTitle = "�������";
        private const string _expectedLoggedUser = "userFirstName userLastName";

        //�������� ����� ������ (�������������)
        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver(); //������� � �������� ����� �����
            _webDriver.Navigate().GoToUrl(Helpers.Base.BASE_URL);
            _webDriver.Manage().Window.Maximize();
        }

        //��� ���� - ������������ � ���������, ��� ������������ �������� ������� "�������"
        [Test]
        public void Test01()
        {
            var authPage = new AuthPageObject(_webDriver);
            authPage.InputLogin();
            authPage.InputPassword();
            authPage.SubmitButton();

            var eventsPage = new EventsPageObject(_webDriver);

            //�������� �������� ������ ��������� (����� �� ������������ �������� Thread.Sleep()
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(_webDriver => _webDriver.FindElement(eventsPage.pageTitle));
            wait.Until(_webDriver => _webDriver.FindElement(eventsPage.userOnPage));

            //��������� � ������ ����������� �����������, ������������ �� ��������
            string actualPageTitle = eventsPage.GetTitle();
            Assert.AreEqual(_expectedPageTitle, actualPageTitle, "����������� �������� �������: "
                                                                    + _expectedPageTitle);

            string actualLoggedUser = eventsPage.GetLoggedUser();
            Assert.AreEqual(_expectedLoggedUser, actualLoggedUser, "������������ ��� ������������ ������������: "
                                                                        + _expectedLoggedUser);

        }


        //�������� ����� ����� (������� �������)
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}