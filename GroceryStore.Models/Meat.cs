using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Meat : Product
{
    public Meat(string name, double price, ProductCategories category = ProductCategories.Meat, int expirationDays = 1)
        : base(name, category, price, expirationDays)
    {
    }
}