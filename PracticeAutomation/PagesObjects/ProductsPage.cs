using OpenQA.Selenium;
using PracticeAutomation.Utility;

namespace PracticeAutomation.PagesObjects
{
    public class ProductsPage
    {
        #region Properties


        #endregion



        #region Methods
        public void SelectProduct(string product)
        {
            Driver.FindElement(By.LinkText(product)).Click();
            Logger.Log.Step(Helper.GetCurrentMethod() + " " + product);

        }
        #endregion
    }
}
