using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.PagesObjects
{
    public class ProductsPage 
    {
        #region Properties


        #endregion



        #region Methods
        public void SelectProduct(string product)
        {
            Driver.FindElement(By.LinkText( product)).Click();
        }
        #endregion
    }
}
