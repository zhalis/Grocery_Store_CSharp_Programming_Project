using GroceryStore.Constants;

namespace GroceryStore.Models;

public static class Shop
{
    private static readonly List<Customer> _customers = new();
    private static readonly List<Product> _products = new();

    public static void AddCustomer(string firstName, string lastName, int age, Sex sex, bool hasDiscountCard,
        double personalDiscount = 0) =>
        _customers.Add(new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount));

    public static void AddCustomer(params Customer[] customers) => _customers.AddRange(customers);

    public static void AddProduct(Product product) => _products.Add(product);

    public static void PrintCustomersInformation()
    {
        var header = $"| {"Full Name",-15} | {"Age",-5} | {"Sex",-5} | {"Has Discount Card",-20} |" +
                     $" {"Personal Discount",-20} | {"Cart",-80} |";
        var separatingLine = new string('-', header.Length);

        Console.WriteLine($"{separatingLine}\n{header}");
        _customers
            .Select(customer => $"{separatingLine}\n{customer}")
            .ForEach(Console.WriteLine);
    }
}