using AventStack.ExtentReports;
using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PracticeAutomation.Tests
{
    class Scenario3: BaseTest
    {



        [Test]
        public void Checkout()
        {
            #region Arrange
            bool OrderConfirmationPageIsOpened = false;
            bool TheOrderIsComplete = false;
            bool CurrentPageIsTheLastStepOfOrdering = false;
            #endregion

            #region Act
            Pages.Home.ClickSignin();
            Pages.Login.Login();
            Pages.Menu.SelectWomenCategory();
            Pages.Products.SelectProduct("Faded Short Sleeve T-shirts");
            Pages.Product.AddToCart();
            Pages.Product.ProceedToCheckout();
            Pages.Order.ProceedToCheckout();
            Pages.Order.ConfirmOrder();

            OrderConfirmationPageIsOpened = PagesObjects.Pages.Order.IsOrderConfirmationPageOpened();
            TheOrderIsComplete = PagesObjects.Pages.Order.IsTheOrderComplete();
            CurrentPageIsTheLastStepOfOrdering = PagesObjects.Pages.Order.IsCurrentPageTheLastStepOfOrdering();
            
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
