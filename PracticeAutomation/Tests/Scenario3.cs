using AventStack.ExtentReports;
using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.Pages;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _productsPage = new ProductsPage(driver);
            _productPage = new ProductPage(driver);
            _orderPage = new OrderPage(driver);
            _menuPage = new MenuPage(driver);
        }

        [Test]
        public void Checkout()
        {
            #region Arrange
            bool OrderConfirmationPageIsOpened = false;
            bool TheOrderIsComplete = false;
            bool CurrentPageIsTheLastStepOfOrdering = false;
            #endregion

            #region Act
            _homePage.ClickSignin();
            _loginPage.Login();
            _menuPage.SelectWomenCategory();
            _productsPage.SelectProduct("Faded Short Sleeve T-shirts");
            _productPage.AddToCart();
            _productPage.ProceedToCheckout();
            _orderPage.ProceedToCheckout();
            _orderPage.ConfirmOrder();

            OrderConfirmationPageIsOpened = _orderPage.IsOrderConfirmationPageOpened();
            TheOrderIsComplete = _orderPage.IsTheOrderComplete();
            CurrentPageIsTheLastStepOfOrdering = _orderPage.IsCurrentPageTheLastStepOfOrdering();
            
            if (OrderConfirmationPageIsOpened)
                extentTest.Log(Status.Pass, "OrderConfirmationPageIsOpened");
            if (TheOrderIsComplete)
                extentTest.Log(Status.Pass, "TheOrderIsComplete");
            if (CurrentPageIsTheLastStepOfOrdering)
                extentTest.Log(Status.Pass, "CurrentPageIsTheLastStepOfOrdering");
            #endregion

            #region Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(OrderConfirmationPageIsOpened, "OrderConfirmationPageIsOpened");
                Assert.IsTrue(TheOrderIsComplete, "TheOrderIsComplete");
                Assert.IsTrue(CurrentPageIsTheLastStepOfOrdering, "CurrentPageIsTheLastStepOfOrdering");
            });
            #endregion
        }

    }
}
