using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using Practice.Test;
using PracticeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Tests
{
    class Scenario1 : BaseTest
    {
        public TestContext TestContext { get; set; }


        [SetUp]
        public void IntializePages()
        {

            _homePage = new HomePage(driver);
            _loginPage = new _loginPage(driver);
            _accountCreationPage = new AccountCreationPage(driver);
            _myAccountPage = new MyAccountPage(driver);

        }

        [Test]
        public void Register()
        {

            #region Arrange
            bool MyAccountPageIsOpened = false;
            bool ProperUsernameIsShownInTheHeader = false;
            bool LogOutActionIsAvailable = false;

            #endregion

            #region Act
            _homePage.ClickSignin();
            _loginPage.EnterEmailAndStartCreatingAccount();
            string Username = _accountCreationPage.FillRegistrationDataAndSubmit();
            MyAccountPageIsOpened = _myAccountPage.IsMyAccountPageOpened();
            ProperUsernameIsShownInTheHeader = _myAccountPage.IsProperUsernameShownInTheHeader(Username);
            LogOutActionIsAvailable = _myAccountPage.IsLogOutActionAvailable();
            if (MyAccountPageIsOpened)
                extentTest.Log(Status.Pass, "MyAccountPageIsOpened");
            if (ProperUsernameIsShownInTheHeader)
                extentTest.Log(Status.Pass, "ProperUsernameIsShownInTheHeader");
            if (LogOutActionIsAvailable)
                extentTest.Log(Status.Pass, "LogOutActionIsAvailable");
            #endregion

            #region Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(MyAccountPageIsOpened, "MyAccountPageIsOpened");
                Assert.IsTrue(ProperUsernameIsShownInTheHeader, "ProperUsernameIsShownInTheHeader");
                Assert.IsTrue(LogOutActionIsAvailable, "LogOutActionIsAvailable");
            });
            #endregion

        }
    }
}
