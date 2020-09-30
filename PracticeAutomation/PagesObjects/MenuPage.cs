using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.PagesObjects
{
    public class MenuPage
    {
        #region Properties
        private IWebElement WomenCategoryLnkElement => Driver.FindElement(By.CssSelector("a[title='Women']"));
        private IWebElement DressesCategoryLnkElement => Driver.FindElement(By.CssSelector("a[title='Dresses']"));
        private IWebElement shirtsCategoryLnkElement => Driver.FindElement(By.CssSelector("a[title='T-shirts']"));
        #endregion


        #region Methods
        internal void SelectCategory(IWebElement category)
        {
            category.Click();
        }

        internal void SelectWomenCategory()
        {
            SelectCategory(WomenCategoryLnkElement);
        }
        #endregion
    }
}
