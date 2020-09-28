using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PracticeAutomation.Utility
{
    class Driver 
    {

        private static IWebDriver _driver;

        public static Driver driver;


        private Driver()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        public static Driver GetDriver()
        {
            if (driver == null)
            {
                driver = new Driver();
            }
            return driver;
        }






        /*
         * 
         * 
         * 	1.	Declare constructor of class as private so that no one instantiate class outside of it.
            2.	Declare a static reference variable of class. Static is needed to make it available globally.
            3.	Declare a static method with return type as object of class which should check if class is already instantiated once
         * 
         * 
         * 
         */
    }
}
