using ShoppingCart.Src;

public class User
{
    private UserID _id;

    public User(UserID userId)
    {
        _id = userId;
    }

    public UserID UserID { get; set; }
}