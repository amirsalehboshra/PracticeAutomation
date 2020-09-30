using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Pages
{
    class ProductsPage
    {
        #region Properties
        private IWebDriver driver;


        #endregion

        #region Constructor
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public void SelectProduct(string product)
        {
            driver.FindElement(By.LinkText( product)).Click();
        }
        #endregion
    }
}
