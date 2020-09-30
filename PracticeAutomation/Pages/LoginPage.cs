using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Pages
{
    class _loginPage
    {
        #region Properties
        private IWebDriver driver;
        private IWebElement EmailCreateTxtBoxElement => driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountBtnElement => driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement EmailTxtBoxElement => driver.FindElement(By.Id("email"));
        private IWebElement PasswordTxtBoxElement => driver.FindElement(By.Id("passwd"));
        private IWebElement LoginBtnElement => driver.FindElement(By.Id("SubmitLogin"));
        #endregion

        #region Constructor
        public _loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public void EnterValidEmailAndStartCreatingAccount()
        {
            EmailCreateTxtBoxElement.SendKeys(Helper.GetRandomMail());
            CreateAccountBtnElement.Click();
        
        }

        public void Login() 
        {
            string email = Helper.GetConfigValueByKey("Email");
            string password = Helper.GetConfigValueByKey("Password");

            EmailTxtBoxElement.SendKeys(email);
            PasswordTxtBoxElement.SendKeys(password);
            LoginBtnElement.Click();
        }
        #endregion
    }
}
