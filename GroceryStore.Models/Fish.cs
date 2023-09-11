using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Fish : Product
{
    public FishTypes FishType { get; }

    public Fish(string name, double price, FishTypes fishType, ProductCategories category = ProductCategories.Fish, 
        int expirationDays = 1) : base(name, category, price, expirationDays)
    {
        FishType = fishType;
    }

    public new string ToString() => 
        $"{base.ToString()}, {FishType}";
}