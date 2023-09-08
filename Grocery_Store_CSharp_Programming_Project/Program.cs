using GroceryStore.Constants;
using GroceryStore.Models;

namespace Grocery_Store_CSharp_Programming_Project;

internal static class Program
{
    public static void Main(string[] args)
    {
        var johnDoe = new Customer("John", "Doe", 22, Sex.M, true, 0.02);
        var samBrooks = new Customer("Sam", "Brooks", 67, Sex.F, true, 0.12);
        var aloisWinter = new Customer("Alois", "Winter", 15, Sex.M, false);
        var annSiemens = new Customer("Ann", "Siemens", 44, Sex.F, true, 0.09);
        var peterParker = new Customer("Peter", "Parker", 9, Sex.M, false);

        var cocaCola = new Product("Coca-Cola", ProductCategories.Drinks, 1.12);
        var tomatoes = new Product("Tomatoes", ProductCategories.FruitAndVegetables, 0.99);
        var laysCheese = new Product("Lay's Cheese", ProductCategories.Snacks, 2.49);
        var norwayHerring = new Product("Norway Herring", ProductCategories.Fish, 4.55);

        annSiemens.UpdateDiscountCardAndPersonalDiscount(false);
        johnDoe.UpdateFirstAndLastNames("John", "Claus");

        var shop = new Shop();
        johnDoe.AddProductsToCart(cocaCola, cocaCola, norwayHerring);
        johnDoe.AddProductsToCart(tomatoes, 7);
        aloisWinter.AddProductsToCart(tomatoes, 3);
        peterParker.AddProductsToCart(laysCheese, 5);
        peterParker.AddProductsToCart(cocaCola, 2);
        shop.AddCustomer(johnDoe, samBrooks, aloisWinter, annSiemens, peterParker);

        shop.PrintCustomersInformation();
    }
}