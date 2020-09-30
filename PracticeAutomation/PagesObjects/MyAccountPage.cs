using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;




namespace PracticeAutomation.PagesObjects
{
    public class MyAccountPage
    {
        #region Properties
        private IWebElement HeaderUsernameLnkElement => Driver.FindElement(By.XPath("//a[contains(@title, 'View my customer account')]/span"));
        private IWebElement LogoutLnkElement => Driver.FindElement(By.XPath("//a[contains(@title, 'View my customer account')]/span"));

        #endregion

        #region Methods
        public bool IsMyAccountPageOpened()
        {
            if (Driver.Current.Url.EndsWith("controller=my-account"))
            {
                return true;
            }
            else
                return false;
        }

        public bool IsProperUsernameShownInTheHeader(string username)
        {
            string _username = HeaderUsernameLnkElement.Text;

            if (_username == username)
            {
                return true;
            }
            else
                return false;
        }

        public bool IsLogOutActionAvailable()
        {
            bool _enabled = LogoutLnkElement.Enabled;
            bool _displayed = LogoutLnkElement.Displayed;

            if (_enabled == true && _displayed== true)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
