﻿using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

        private IWebElement HeaderUsernameLnkElement => driver.FindElement(By.XPath("//*[contains(@title, 'View my customer account')]/span"));
        private IWebElement LogoutLnkElement => driver.FindElement(By.XPath("//*[contains(@title, 'View my customer account')]/span"));

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
            {
                return true;
            }else
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
