using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Tests
{
    [TestFixture]
    class Testing : MainSetup
    {

        private HomePage _homePage;
        private LoginPage _loginPage;
        private AccountCreationPage _accountCreationPage;
        private MyAccountPage _myAccountPage;

        [SetUp]
        public void IntializePages()
        {
            _homePage = new HomePage(driver);
            _loginPage = new LoginPage(driver);
            _accountCreationPage = new AccountCreationPage(driver);
            _myAccountPage = new MyAccountPage(driver);

        }



        [Test]
        public void Scenario1_SignIn()
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

        [Test]
        public void Scenario2_LoginIn()
        {
            #region Arrange
            bool MyAccountPageIsOpened = false;
            bool ProperUsernameIsShownInTheHeader = false;
            bool LogOutActionIsAvailable = true;
            #endregion

            #region Act
            _homePage.ClickSignin();
            _loginPage.Login();
            string Username = "Amir Saleh";
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

        [Test]
        public void Scenario3()
        {
            _homePage.ClickSignin();
        }
    }
}
