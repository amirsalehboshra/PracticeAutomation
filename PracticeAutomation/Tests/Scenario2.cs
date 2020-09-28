using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using RazorEngine.Compilation.ImpromptuInterface.Build;
using PracticeAutomation.Utility;

namespace PracticeAutomation.Tests
{
    class Scenario2: BaseTest
    {

        [SetUp]
        public void IntializePages()
        {


            _homePage = new HomePage(driver);
            _loginPage = new _loginPage(driver);
            _accountCreationPage = new AccountCreationPage(driver);
            _myAccountPage = new MyAccountPage(driver);

        }

        [Test]
        public void LoginIn()
        {
            #region Arrange
            bool MyAccountPageIsOpened = false;
            bool ProperUsernameIsShownInTheHeader = false;
            bool LogOutActionIsAvailable = true;
            #endregion

            #region Act
            //var _loginPage = PageFactory.InitElements<_loginPage>(driver);

            _homePage.ClickSignin();
            _loginPage.Login();
            string Username = Helper.GetConfigValueByKey("Username");
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
