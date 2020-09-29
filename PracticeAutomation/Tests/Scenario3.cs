using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.Tests
{
    class Scenario3: BaseTest
    {

        [SetUp]
        public void IntializePages()
        {


            _homePage = new HomePage(driver);
            _loginPage = new _loginPage(driver);
            _accountCreationPage = new AccountCreationPage(driver);
            _myAccountPage = new MyAccountPage(driver);

        }
        [Test]
        public void Checkout()
        {

            _homePage.ClickSignin();
        }

    }
}
