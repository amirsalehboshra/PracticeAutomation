﻿using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;
using AventStack.ExtentReports;

namespace PracticeAutomation.Tests
{
    class Scenario2 : BaseTest
    {
        [Test]
        public void LoginIn()
        {
            #region Arrange
            bool MyAccountPageIsOpened = false;
            bool ProperUsernameIsShownInTheHeader = false;
            bool LogOutActionIsAvailable = false;
            #endregion

            #region Act
            Pages.Home.ClickSignin();
            Pages.Login.Login();

            string Username = Helper.GetConfigValueByKey("Username");
            MyAccountPageIsOpened = Pages.MyAccount.IsMyAccountPageOpened();
            ProperUsernameIsShownInTheHeader = Pages.MyAccount.IsProperUsernameShownInTheHeader(Username);
            LogOutActionIsAvailable = Pages.MyAccount.IsLogOutActionAvailable();

            if (MyAccountPageIsOpened)
                ReportingManager.extentTest.Log(Status.Pass, "MyAccountPageIsOpened");
            if (ProperUsernameIsShownInTheHeader)
                ReportingManager.extentTest.Log(Status.Pass, "ProperUsernameIsShownInTheHeader");
            if (LogOutActionIsAvailable)
                ReportingManager.extentTest.Log(Status.Pass, "LogOutActionIsAvailable");
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
