using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeAutomation.Pages
{
    class OrderPage
    {
        #region Properties
        private IWebDriver driver;
        private IWebElement ProceedToCheckoutBtnElement01 => driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium"));
        private IWebElement ProceedToCheckoutBtnElement03 => driver.FindElement(By.CssSelector("button[name='processAddress']"));
        private IWebElement ProceedToCheckoutBtnElement04 => driver.FindElement(By.CssSelector("button[name='processCarrier']"));
        private IWebElement TermsOfserviceChkBoxElement => driver.FindElement(By.Id("cgv"));
        private IWebElement PayByBankWireLnkElement => driver.FindElement(By.CssSelector("a[title='Pay by bank wire']"));
        private IWebElement ConfirmOrderBtnElement => driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
        private IWebElement PageTitleElement => driver.FindElement(By.XPath("//*[@id='center_column']/h1"));
        private IWebElement PageLastStepElement => driver.FindElement(By.Id("step_end"));
        private IWebElement CartProductsCountElement => driver.FindElement(By.XPath("//*[@id='header']/div[3]/div/div/div[3]/div/a/span[5]"));
        #endregion

        #region Constructor
        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods

        public void ProceedToCheckout()
        {
            //WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            // ProceedToCheckoutBtnElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable);

            ProceedToCheckoutBtnElement01.Click();
            ProceedToCheckoutBtnElement03.Click();
            TermsOfserviceChkBoxElement.Click();
            ProceedToCheckoutBtnElement04.Click();
        }

        public void ConfirmOrder()
        {
            PayByBankWireLnkElement.Click();
            ConfirmOrderBtnElement.Click();
        }

        public bool IsTheOrderComplete()
        {
            if (CartProductsCountElement.Text.Contains("empty"))
                return true;
            return false;
        }

        public bool IsOrderConfirmationPageOpened()
        {
            if (PageTitleElement.Text == "ORDER CONFIRMATION")
                return true;
            return false;
        }

        public bool IsCurrentPageTheLastStepOfOrdering()
        {
            if (PageLastStepElement.GetAttribute("Class").Contains("step_current"))
                return true;
            return false;
        }
        #endregion
    }
}
