using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Drink : Product
{
    public bool IsAlcohol { get; }
    public double Volume { get; }

    public Drink(string name, double price, double volume, bool isAlcohol = false, 
        ProductCategories category = ProductCategories.Drinks, int expirationDays = 30) 
        : base(name, category, price, expirationDays)
    {
        IsAlcohol = isAlcohol;
        Volume = volume;
    }

    public new string ToString() => 
        $"{base.ToString()}, Vol. - {Volume}, Alcohol - {(IsAlcohol ? "Y" : "N")}";
}