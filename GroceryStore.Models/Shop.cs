namespace GroceryStore.Models;

public class Shop
{
    private readonly List<Customer> _customers = new();
    private readonly List<Product> _products = new();

    public void AddCustomer(string firstName, string lastName, int age, Sex sex, bool hasDiscountCard,
        double personalDiscount = 0) =>
        _customers.Add(new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount));

    public void AddCustomer(params Customer[] customers) => _customers.AddRange(customers);

    public void PrintCustomersInformation()
    {
        var header = $"| {"Full Name",-15} | {"Age",-5} | {"Sex",-5} | {"Has Discount Card",-20} |" +
                     $" {"Personal Discount",-20} | {"Cart",-60} |";
        var separatingLine = new string('-', header.Length);

        Console.WriteLine($"{separatingLine}\n{header}");
        _customers
            .Select(customer => $"{separatingLine}\n{customer.GetCustomerInfo()}")
            .ToList()
            .ForEach(Console.WriteLine);
    }
}