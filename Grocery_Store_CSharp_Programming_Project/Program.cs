using GroceryStore.Constants;
using GroceryStore.Models;

namespace Grocery_Store_CSharp_Programming_Project;

internal static class Program
{
    public static void Main(string[] args)
    {
        var johnDoe = new Customer("John", "Doe", 22, SexTypes.M, true, 0.02);
        var samBrooks = new Customer("Sam", "Brooks", 67, SexTypes.F, true, 0.12);
        var aloisWinter = new Customer("Alois", "Winter", 15, SexTypes.M, false);
        var annSiemens = new Customer("Ann", "Siemens", 44, SexTypes.F, true, 0.09);
        var peterParker = new Customer("Peter", "Parker", 9, SexTypes.M, false);

        var cocaCola = new Drink("Coca-Cola", 1.12, 0.5);
        var tomatoes = new FruitsAndVegetables("Tomatoes", 0.99, 0.5);
        var laysCheese = new Snacks("Lay's Cheese", 2.49);
        var norwayHerring = new Fish("Norway Herring", 4.55, FishTypes.Ocean);
        var aperol = new Drink("Aperol", 9.99, 0.75, true);
        var chickenNuggets = new Meat("Chicken Nuggets", 4.99);

        johnDoe.AddProductsToCart(cocaCola, cocaCola, norwayHerring);
        johnDoe.AddProductsToCart(tomatoes, 7);
        aloisWinter.AddProductsToCart(tomatoes, 3);
        peterParker.AddProductsToCart(laysCheese, 5);
        peterParker.AddProductsToCart(cocaCola, 2);
        annSiemens.AddProductsToCart(aperol);
        samBrooks.AddProductsToCart(chickenNuggets);
        peterParker.AddProductsToCart(aperol);
        
        Shop.AddProduct(cocaCola, tomatoes, laysCheese, norwayHerring, aperol, chickenNuggets);
        Shop.AddCustomer(johnDoe, samBrooks, aloisWinter, annSiemens, peterParker);

        annSiemens.UpdateDiscountCardAndPersonalDiscount(false);
        Shop.UpdateCustomer(annSiemens);
        johnDoe.UpdateFirstAndLastNames("John", "Claus");
        Shop.UpdateCustomer(johnDoe);
        
        Shop.PrintCustomersInformation();
    }
}