using NUnit.Framework;
using OpenQA.Selenium;
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
            bool LogOutActionIsAvailable = true;
            #endregion

            #region Act
            _homePage.ClickSignin();
            _loginPage.EnterEmailAndStartCreatingAccount();
            string Username = _accountCreationPage.FillRegistrationDataAndSubmit();
            MyAccountPageIsOpened = _myAccountPage.IsMyAccountPageOpened();
            ProperUsernameIsShownInTheHeader = _myAccountPage.IsProperUsernameShownInTheHeader(Username);
            LogOutActionIsAvailable = _myAccountPage.IsLogOutActionAvailable();
            #endregion

            #region Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(MyAccountPageIsOpened);
                Assert.IsTrue(ProperUsernameIsShownInTheHeader);
                Assert.IsTrue(LogOutActionIsAvailable);
            });
            #endregion

        }
    }
}
