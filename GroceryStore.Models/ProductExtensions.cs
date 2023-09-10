namespace GroceryStore.Models;

public static class ProductExtensions
{
    public static string ToStringExt(this Product product) =>
        product switch
        {
            Fish fish => fish.ToString(),
            Meat meat => meat.ToString(),
            Drink drink => drink.ToString(),
            FruitsAndVegetables fruitOrVegetable => fruitOrVegetable.ToString(),
            Snacks snack => snack.ToString(),
            _ => product.ToString()
        };
}