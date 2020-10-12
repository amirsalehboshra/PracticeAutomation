using OpenQA.Selenium;
using PracticeAutomation.Utility;

namespace PracticeAutomation.PagesObjects
{
    public class loginPage
    {
        #region Elements
        private IWebElement EmailCreateTxtBoxElement => Driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountBtnElement => Driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement EmailTxtBoxElement => Driver.FindElement(By.Id("email"));
        private IWebElement PasswordTxtBoxElement => Driver.FindElement(By.Id("passwd"));
        private IWebElement LoginBtnElement => Driver.FindElement(By.Id("SubmitLogin"));
        #endregion



        #region Methods
        public void EnterValidEmailAndStartCreatingAccount()
        {
            EmailCreateTxtBoxElement.SendKeys(Helper.GetRandomMail());
            CreateAccountBtnElement.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());
        }

        public void Login()
        {
            string email = Helper.GetConfigValueByKey("LoginConfig", "Email");
            string password = Helper.GetConfigValueByKey("LoginConfig", "Password");

            EmailTxtBoxElement.SendKeys(email);
            PasswordTxtBoxElement.SendKeys(password);
            LoginBtnElement.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());
        }
        #endregion
    }
}
