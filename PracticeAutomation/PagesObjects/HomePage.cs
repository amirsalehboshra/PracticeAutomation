using OpenQA.Selenium;
using PracticeAutomation.Utility;

namespace PracticeAutomation.PagesObjects
{
    public class HomePage
    {

        public IWebElement LoginLinkElement => Driver.FindElement(By.CssSelector("a[title='Log in to your customer account']"));


        public void ClickSignin()
        {
            LoginLinkElement.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());
        }
    }


}
