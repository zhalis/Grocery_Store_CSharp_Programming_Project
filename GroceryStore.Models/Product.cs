using System.Text.Json.Serialization;
using GroceryStore.Constants;

namespace GroceryStore.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "category")]
[JsonDerivedType(typeof(FruitsAndVegetables), 0)]
[JsonDerivedType(typeof(Meat), 1)]
[JsonDerivedType(typeof(Fish), 2)]
[JsonDerivedType(typeof(Snacks), 3)]
[JsonDerivedType(typeof(Drink), 4)]
public abstract class Product
{
    public string Name { get; }
    public ProductCategories Category { internal get; set; }
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

    public bool Equals(Product other) =>
        Name == other.Name && Category == other.Category && ExpirationDays == other.ExpirationDays &&
        Price.Equals(other.Price);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        
        return obj.GetType() == GetType() && Equals((Product)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Name, (int)Category, ExpirationDays, Price);
}