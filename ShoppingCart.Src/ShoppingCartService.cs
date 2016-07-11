namespace ShoppingCart.Src
{
    public class ShoppingCartService
    {
        private ICalendar _calendar;
        private IPrinter _printer;
        private IProductRepo _productRepo;

        public ShoppingCartService(ICalendar calendar, IPrinter printer, IProductRepo productRepo)
        {
            _calendar = calendar;
            _printer = printer;
            _productRepo = productRepo;
        }

        public void AddProduct(UserID userID, ProductID productId, int quantity)
        {
            var product = _productRepo.FindBy(productId);
            var total = product.GetTotal(quantity);
            _printer.Print($"[ITEM ADDED TO SHOPPING CART]: " +
                           $"Date[<{_calendar.Today()}>], " +
                           $"User[<{userID.Id}>], Item[{productId.Id}]," +
                           $" Quantity[<{quantity}>]," +
                           $" Total price[<{total}>]");
        }
    }
}