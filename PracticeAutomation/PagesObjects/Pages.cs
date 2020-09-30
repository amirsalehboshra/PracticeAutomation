using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAutomation.PagesObjects
{
    public class Pages
    {
        [ThreadStatic]
        public static HomePage Home;

        [ThreadStatic]
        public static loginPage Login;

        [ThreadStatic]
        public static MenuPage Menu;

        [ThreadStatic]
        public static MyAccountPage MyAccount;

        [ThreadStatic]
        public static OrderPage Order;

        [ThreadStatic]
        public static ProductsPage Products;

        [ThreadStatic]
        public static ProductPage Product;

        [ThreadStatic]
        public static AccountCreationPage AccountCreation;



        public static void Init()
        {
            Home = new HomePage();
            Login = new loginPage();
            Menu = new MenuPage();
            MyAccount = new MyAccountPage();
            Order = new OrderPage();
            Product = new ProductPage();
            Products = new ProductsPage();
            AccountCreation = new AccountCreationPage();
        }
    }
}
