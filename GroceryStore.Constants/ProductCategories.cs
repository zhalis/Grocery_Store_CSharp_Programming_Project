using System.ComponentModel;

namespace GroceryStore.Constants;

public enum ProductCategories
{
    [Description("Fruits & Vegetables")] FruitAndVegetables,
    [Description("Meat")] Meat,
    [Description("Fish")] Fish,
    [Description("Snacks")] Snacks,
    [Description("Drinks")] Drinks
}