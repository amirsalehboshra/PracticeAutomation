using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System.Collections.Generic;
using System.Linq;

namespace PracticeAutomation.PagesObjects
{
    public class OrderPage
    {
        #region Properties
        private IList<IWebElement> ProceedToCheckoutBtnElements => Driver.FindElements(By.CssSelector("a[title = 'Proceed to checkout']"));

        //  private IWebElement ProceedToCheckoutBtnElement01 => Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium"));
        private IWebElement ProceedToCheckoutBtnElement03 => Driver.FindElement(By.CssSelector("button[name='processAddress']"));
        private IWebElement ProceedToCheckoutBtnElement04 => Driver.FindElement(By.CssSelector("button[name='processCarrier']"));
        private IWebElement TermsOfserviceChkBoxElement => Driver.FindElement(By.Id("cgv"));
        private IWebElement PayByBankWireLnkElement => Driver.FindElement(By.CssSelector("a[title='Pay by bank wire']"));
        private IWebElement ConfirmOrderBtnElement => Driver.FindElement(By.XPath("//p[@id='cart_navigation']/button"));
        private IWebElement PageTitleElement => Driver.FindElement(By.XPath("//div[@id='center_column']/h1"));
        private IWebElement PageLastStepElement => Driver.FindElement(By.Id("step_end"));
        private IWebElement CartProductsCountElement => Driver.FindElement(By.XPath("//header[@id='header']/div[3]/div/div/div[3]/div/a/span[5]"));
        #endregion


        #region Methods

        public void ProceedToCheckout()
        {
            ProceedToCheckoutBtnElements.LastOrDefault().Click();

            // ProceedToCheckoutBtnElement01.Click();
            ProceedToCheckoutBtnElement03.Click();
            TermsOfserviceChkBoxElement.Click();
            ProceedToCheckoutBtnElement04.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());

        }

        public void ConfirmOrder()
        {
            PayByBankWireLnkElement.Click();
            ConfirmOrderBtnElement.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());

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
