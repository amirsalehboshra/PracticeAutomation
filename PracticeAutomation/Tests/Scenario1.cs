using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using Practice.Test;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Tests
{
    class Scenario1 : BaseTest
    {
        public TestContext TestContext { get; set; }




        [Test]
        public void Register()
        {

            #region Arrange
            bool MyAccountPageIsOpened = false;
            bool ProperUsernameIsShownInTheHeader = false;
            bool LogOutActionIsAvailable = false;

            #endregion

            #region Act
            Pages.Home.ClickSignin();
            Pages.Login.EnterValidEmailAndStartCreatingAccount();
            string Username = Pages.AccountCreation.FillRegistrationDataAndSubmit();
            MyAccountPageIsOpened = Pages.MyAccount.IsMyAccountPageOpened();
            ProperUsernameIsShownInTheHeader = Pages.MyAccount.IsProperUsernameShownInTheHeader(Username);
            LogOutActionIsAvailable = Pages.MyAccount.IsLogOutActionAvailable();
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
