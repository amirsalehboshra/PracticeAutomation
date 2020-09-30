using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Pages
{
    class MenuPage
    {
        #region Properties
        private IWebDriver driver;

        private IWebElement WomenCategoryLnkElement => driver.FindElement(By.CssSelector("a[title='Women']"));
        private IWebElement DressesCategoryLnkElement => driver.FindElement(By.CssSelector("a[title='Dresses']"));
        private IWebElement shirtsCategoryLnkElement => driver.FindElement(By.CssSelector("a[title='T-shirts']"));
        #endregion

        #region Constructor
        public MenuPage(IWebDriver driver)
        {
            this.driver = driver;
        }
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
