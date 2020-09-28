using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PracticeAutomation.Pages
{
    class MyAccountPage
    {
        #region Properties
        private IWebDriver driver;


        By _headerUsernameLnk = By.CssSelector("a[title='View my customer account'] > span");
        By _logoutLnk = By.CssSelector("a[title='Log me out']");
        #endregion

        #region Constructor 
        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;   
        }
        #endregion

        #region Methods
        public bool IsMyAccountPageOpened()
        {
            if (driver.Url.EndsWith("controller=my-account"))
                return true;
            return false;
        }

        public bool IsProperUsernameShownInTheHeader(string username)
        {
           string _username = driver.FindElement(_headerUsernameLnk).Text;

            if (_username == username)
                return true;
            return false;
        }

        public bool IsLogOutActionAvailable()
        {
            bool _enabled = driver.FindElement(_logoutLnk).Enabled;
            bool _displayed = driver.FindElement(_logoutLnk).Displayed;

            if (_enabled == true && _displayed== true)
                return true;
            return false;
        }
        #endregion
    }
}
