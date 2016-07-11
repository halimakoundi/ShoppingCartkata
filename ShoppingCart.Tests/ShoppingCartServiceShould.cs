using NSubstitute;
using NUnit.Framework;
using ShoppingCart.Src;

namespace ShoppingCart.Tests
{
    [TestFixture]
    public class ShoppingCartServiceShould
    {
        [Test]
        public void log_when_adding_item_to_cart()
        {
            var printer = Substitute.For<IPrinter>();
            var calendar = Substitute.For<ICalendar>();
            var productRepo = Substitute.For<IProductRepo>();

            var user = new User(new UserID("Customer-01"));
            var item1 = new Product(10.00, new ProductID("10001"));
            var quantity1 = 1;
            var date1 = "2016-07-10";
            productRepo.FindBy(item1.ProductID).Returns(item1);

            var shoppingService = new ShoppingCartService(calendar, printer, productRepo);
            shoppingService.AddProduct(user.UserID, item1.ProductID, quantity1);

            var message = $"[ITEM ADDED TO SHOPPING CART]: Date[<{date1}>], User[<{user.UserID}>], Item[{item1.ProductID}], Quantity[<{quantity1}>], Total price[<{(10.00)}>]";
            printer.Received(1).Print(message);
        }
    }
}
