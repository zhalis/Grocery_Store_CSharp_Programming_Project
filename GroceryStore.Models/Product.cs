using GroceryStore.Constants;

namespace GroceryStore.Models;

public class Product
{
    public string Name { get; }
    public ProductCategories Category { get; }
    public double Price { get; }
    
    public Product(string name, ProductCategories category, double price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public string GetProductInfo() => $"({Category.GetDescription()}) {Name} {Price:C2}";
}