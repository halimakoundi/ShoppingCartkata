using System;
using ShoppingCart.Src;

public class Product
{
    private readonly ProductID _productId;

    public Product(double price, ProductID productID)
    {
        _productId = productID;
        Price = price;
    }

    public Double Price { get; set; }
    public ProductID ProductID { get; set; }

    public Double GetTotal(int quantity)
    {
        throw new NotImplementedException();
    }
}