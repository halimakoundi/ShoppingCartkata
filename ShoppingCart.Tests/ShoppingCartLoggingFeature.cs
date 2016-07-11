using System;
using NSubstitute;
using NUnit.Framework;
using ShoppingCart.Src;

namespace ShoppingCart.Tests
{
    [TestFixture]
    public class ShoppingCartLoggingFeature
    {
        [Test]
        public void should_log_when_item_is_added_to_cart()
        {
            var calendar = Substitute.For<ICalendar>();
            calendar.Today().Returns("2016-07-10");

            var printer = Substitute.For<IPrinter>();

            var user = new User(new UserID("Customer-01"));
            var item1 = new Product(10.00, new ProductID("10001"));
            var quantity1 = 1;
            var item2 = new Product(5.00, new ProductID("10002"));
            var quantity2 = 3;

            var productRepo = Substitute.For<IProductRepo>();
            var shoppingCartService = new ShoppingCartService(calendar, printer, productRepo);
            shoppingCartService.AddProduct(user.UserID, item1.ProductID, quantity1);
            shoppingCartService.AddProduct(user.UserID, item2.ProductID, quantity2);


            var date1   = "2016-07-10";

            Received.InOrder(() =>
            {
                printer.Print($"[ITEM ADDED TO SHOPPING CART]: Date[<{date1}>], User[<{user.UserID}>], Item[{item1.ProductID}], Quantity[<{quantity1}>], Total price[<{(10.00)}>]");
                printer.Print($"[ITEM ADDED TO SHOPPING CART]: Date[<{date1}>], User[<{user.UserID}>], Item[{item2.ProductID}], Quantity[<{quantity2}>], Total price[<{(15.00)}>]");
            });
        }
    }

}
