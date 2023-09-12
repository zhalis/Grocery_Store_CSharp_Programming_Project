using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GroceryStore.Constants;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductCategories
{
    [Description("Fruits & Vegetables")] FruitAndVegetables,
    [Description("Meat")] Meat,
    [Description("Fish")] Fish,
    [Description("Snacks")] Snacks,
    [Description("Drinks")] Drinks
}