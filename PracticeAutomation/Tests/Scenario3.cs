using NUnit.Framework;
using Practice.Test;
using PracticeAutomation.PagesObjects;
using PracticeAutomation.Utility;

namespace PracticeAutomation.Tests
{
    [Parallelizable(ParallelScope.All)]
    class Scenario3 : BaseTest
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
            Pages.Products.SelectProduct(Helper.GetConfigValueByKey("Product"));
            Pages.Product.AddToCart();
            Pages.Product.ProceedToCheckout();
            Pages.Order.ProceedToCheckout();
            Pages.Order.ConfirmOrder();

            OrderConfirmationPageIsOpened = PagesObjects.Pages.Order.IsOrderConfirmationPageOpened();
            TheOrderIsComplete = PagesObjects.Pages.Order.IsTheOrderComplete();
            CurrentPageIsTheLastStepOfOrdering = PagesObjects.Pages.Order.IsCurrentPageTheLastStepOfOrdering();

            if (OrderConfirmationPageIsOpened)
                ReportingManager.extentTest.Pass("OrderConfirmationPageIsOpened");
            if (TheOrderIsComplete)
                ReportingManager.extentTest.Pass("TheOrderIsComplete");
            if (CurrentPageIsTheLastStepOfOrdering)
                ReportingManager.extentTest.Pass("CurrentPageIsTheLastStepOfOrdering");
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
