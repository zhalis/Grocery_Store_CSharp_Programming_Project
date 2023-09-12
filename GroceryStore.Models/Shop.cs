using GroceryStore.Constants;
using GroceryStore.Core.Helpers;

namespace GroceryStore.Models;

public static class Shop
{
    private const string CustomersFilePath = "Resources/customers.json";
    private const string ProductsFilePath = "Resources/products.json";

    private static readonly ISet<Customer> Customers =
        new HashSet<Customer>(JsonHelper.GetData<Customer>(CustomersFilePath));

    private static readonly ISet<Product> Products =
        new HashSet<Product>(JsonHelper.GetData<Product>(ProductsFilePath));

    public static void AddCustomer(string firstName, string lastName, int age, SexTypes sexTypes, bool hasDiscountCard,
        double personalDiscount = 0) =>
        Customers.AddCustomer(new Customer(firstName, lastName, age, sexTypes, hasDiscountCard, personalDiscount));

    public static void AddCustomer(params Customer[] customers) =>
        customers.ForEach(customer => Customers.AddCustomer(customer));

    public static void AddProduct(params Product[] products) =>
        products.ForEach(product => Products.AddProduct(product));

    public static void UpdateCustomer(Customer updatedCustomer)
    {
        var customerToReplace = Customers.First(customer => updatedCustomer.Id.Equals(customer.Id));
        Customers.Remove(customerToReplace);
        Customers.AddCustomer(updatedCustomer);
    }

    public static Customer GetCustomer(string fullName) =>
        Customers.First(customer => fullName.Equals(customer.FullName));

    public static void PrintCustomersInformation()
    {
        var header = $"| {"Full Name",-15} | {"Age",-5} | {"Sex",-5} | {"Has Discount Card",-20} |" +
                     $" {"Personal Discount",-20} | {"Cart",-80} |";
        var separatingLine = new string('-', header.Length);

        Console.WriteLine($"{separatingLine}\n{header}");
        Customers
            .Select(customer => $"{separatingLine}\n{customer}")
            .ForEach(Console.WriteLine);
    }
}