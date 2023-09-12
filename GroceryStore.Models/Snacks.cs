using System.Text.Json.Serialization;
using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Snacks : Product
{
    public bool IsNoFat { get; }

    [JsonConstructor]
    public Snacks(string name, double price, ProductCategories category = ProductCategories.Snacks, 
        bool isNoFat = false, int expirationDays = 90) : base(name, category, price, expirationDays)
    {
        IsNoFat = isNoFat;
    }

    public new string ToString() => 
        $"{base.ToString()}, Fat - {(IsNoFat ? "N" : "Y")}";
}