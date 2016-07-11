namespace ShoppingCart.Src
{
    public interface IProductRepo
    {
        Product FindBy(ProductID id);
    }
}