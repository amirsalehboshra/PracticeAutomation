using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.PagesObjects
{
    public class ProductPage
    {
        #region Properties
        private IWebElement AddToCartBtnElement => Driver.FindElement(By.CssSelector("button[name='Submit']"));
        private IWebElement ProceedToCheckoutBtnElement => Driver.FindElement(By.CssSelector("a[title='Proceed to checkout']"));
        #endregion


        #region Methods
        public void AddToCart()
        {
            AddToCartBtnElement.Click();
        }

        public void ProceedToCheckout()
        {
            ProceedToCheckoutBtnElement.Click();
        }
        #endregion
    }
}
