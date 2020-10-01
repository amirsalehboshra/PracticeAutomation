using NUnit.Framework;
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

        public IWebElement LoginLinkElement => Driver.FindElement(By.CssSelector("a[title='Log in to your customer account']"));


        public void ClickSignin()
        {
            LoginLinkElement.Click();
            Logger.Log.Step(Helper.GetCurrentMethod());
        }
    }


}
