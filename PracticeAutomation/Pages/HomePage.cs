using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PracticeAutomation.Pages
{
    class HomePage
    {
        #region Properties
        private IWebDriver driver;
        By LoginLink = By.CssSelector("a[title='Log in to your customer account']");
        #endregion

        #region Constructor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public void ClickSignin()
        {
            driver.FindElement(LoginLink).Click();
        }
        #endregion
    }
}
