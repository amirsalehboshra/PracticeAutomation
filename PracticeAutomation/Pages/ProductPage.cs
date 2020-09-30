using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Pages
{
    class ProductPage
    {
        #region Properties
        private IWebDriver driver;

        private IWebElement AddToCartBtnElement => driver.FindElement(By.CssSelector("button[name='Submit']"));
        private IWebElement ProceedToCheckoutBtnElement => driver.FindElement(By.CssSelector("a[title='Proceed to checkout']"));
        #endregion

        #region Constructor
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }
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
