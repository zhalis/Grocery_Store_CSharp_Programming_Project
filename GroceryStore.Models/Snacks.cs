using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Snacks : Product
{
    public bool IsNoFat { get; }

    public Snacks(string name, double price, ProductCategories category = ProductCategories.Snacks, 
        bool isNoFat = false, int days = 90) : base(name, category, price, days)
    {
        IsNoFat = isNoFat;
    }

    public new string ToString() => 
        $"{base.ToString()}, Fat - {(IsNoFat ? "N" : "Y")}";
}