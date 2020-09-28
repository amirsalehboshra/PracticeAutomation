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
        By EmailCreateTxtBox = By.Id("email_create");
        By CreateAccountBtn = By.Id("SubmitCreate");
        By EmailTxtBox = By.Id("email");
        By PasswordTxtBox = By.Id("passwd");
        By LoginBtn = By.Id("SubmitLogin");
        #endregion

        #region Constuctor
        public _loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public void EnterEmailAndStartCreatingAccount()
        {
            driver.FindElement(EmailCreateTxtBox).SendKeys(Helper.GetRandomMail());
            driver.FindElement(CreateAccountBtn).Click();
        
        }

        public void Login() 
        {
            string email = Helper.GetConfigValueByKey("Email");
            string password = Helper.GetConfigValueByKey("Password");

            driver.FindElement(EmailTxtBox).SendKeys(email);
            driver.FindElement(PasswordTxtBox).SendKeys(password);
            driver.FindElement(LoginBtn).Click();
        
        }
        #endregion
    }
}
