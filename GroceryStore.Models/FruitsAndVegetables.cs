using System.Text.Json.Serialization;
using GroceryStore.Constants;

namespace GroceryStore.Models;

public class FruitsAndVegetables : Product
{
    public double Weight { get; }

    [JsonConstructor]
    public FruitsAndVegetables(string name, double price, double weight, 
        ProductCategories category = ProductCategories.FruitAndVegetables, int expirationDays = 4) 
        : base(name, category, price, expirationDays)
    {
        Weight = weight;
    }

    public new string ToString() => 
        $"{base.ToString()}, {Weight}kg";
}