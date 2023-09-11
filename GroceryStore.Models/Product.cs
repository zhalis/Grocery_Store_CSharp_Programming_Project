using GroceryStore.Constants;

namespace GroceryStore.Models;

public abstract class Product
{
    public string Name { get; }
    public ProductCategories Category { get; }
    public int ExpirationDays { get; }
    public double Price { get; }
    public DateTime ExpirationDate => DateTime.Today.AddDays(ExpirationDays);

    protected Product(string name, ProductCategories category, double price, int expirationDays = 1)
    {
        Name = name;
        Category = category;
        ExpirationDays = expirationDays;
        Price = price;
    }

    public override string ToString() =>
        $"({Category.GetDescription()}) {Name} {Price:C2}, Exp. {ExpirationDate:dd.MM.yyyy}";
}