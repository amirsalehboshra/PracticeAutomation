using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;

namespace PracticeAutomation.Tests
{
    [Parallelizable(ParallelScope.All)]
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

            string Username = Helper.GetConfigValueByKey("LoginConfig", "Username");
            //  MyAccountPageIsOpened = Pages.MyAccount.IsMyAccountPageOpened();
            ProperUsernameIsShownInTheHeader = Pages.MyAccount.IsProperUsernameShownInTheHeader(Username);
            LogOutActionIsAvailable = Pages.MyAccount.IsLogOutActionAvailable();

            if (MyAccountPageIsOpened)
                ReportingManager.extentTest.Pass("MyAccountPageIsOpened");
            if (ProperUsernameIsShownInTheHeader)
                ReportingManager.extentTest.Pass("ProperUsernameIsShownInTheHeader");
            if (LogOutActionIsAvailable)
                ReportingManager.extentTest.Pass("LogOutActionIsAvailable");
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
