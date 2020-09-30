using OpenQA.Selenium;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PracticeAutomation.PagesObjects
{
    public class HomePage
    {

        public readonly HomePageMap Map;

        public HomePage()
        {
            Map = new HomePageMap();
        }

        public void ClickSignin()
        {
            Map.LoginLinkElement.Click();
        }
    }

    public class HomePageMap
    {
        public IWebElement LoginLinkElement => Driver.FindElement(By.CssSelector("a[title='Log in to your customer account']"));
    }

}
