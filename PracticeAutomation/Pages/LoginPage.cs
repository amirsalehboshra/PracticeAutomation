using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Pages
{
    class LoginPage
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
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public void EnterEmailAndStartCreatingAccount()
        {
            driver.FindElement(EmailCreateTxtBox).SendKeys("amir+" + Helper.GetRandomNumber(0,1000) + Helper.GetRandomNumber(0, 1000) + "@gmail.com");
            driver.FindElement(CreateAccountBtn).Click();
        
        }

        public void Login() 
        {
            driver.FindElement(EmailTxtBox).SendKeys("amir+Login@gmail.com");
            driver.FindElement(PasswordTxtBox).SendKeys("p@ssw0rd");
            driver.FindElement(LoginBtn).Click();
        
        }
        #endregion
    }
}
