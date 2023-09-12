using System.Text.Json.Serialization;
using GroceryStore.Constants;
using GroceryStore.Core.Exceptions;

namespace GroceryStore.Models;

public class Customer
{
    public Guid Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    [JsonIgnore] public string FullName => $"{FirstName} {LastName}";
    public int Age { get; }
    public SexTypes Sex { get; }
    public bool HasDiscountCard { get; private set; }
    public double PersonalDiscount { get; private set; }
    public ICollection<Product> Cart { get; } = new List<Product>();

    public Customer(string firstName, string lastName, int age, SexTypes sex, bool hasDiscountCard,
        double personalDiscount = 0)
    {
        Id = Guid.NewGuid();
        Age = age;
        Sex = sex;
        FirstName = firstName;
        LastName = lastName;
        UpdateDiscountCardAndPersonalDiscount(hasDiscountCard, personalDiscount);
    }

    [JsonConstructor]
    public Customer(Guid id, string firstName, string lastName, int age, SexTypes sex, bool hasDiscountCard,
        ICollection<Product> cart, double personalDiscount = 0)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Sex = sex;
        UpdateDiscountCardAndPersonalDiscount(hasDiscountCard, personalDiscount);
        Cart = cart;
    }

    public void UpdateDiscountCardAndPersonalDiscount(bool hasDiscountCard, double personalDiscount = 0)
    {
        HasDiscountCard = hasDiscountCard;
        PersonalDiscount = hasDiscountCard ? personalDiscount : 0;
    }

    public void UpdateFirstAndLastNames(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private void AddProduct<T>(T product) where T : Product
    {
        ValidateAgeAvailability(product);
        ValidateExpirationDate(product);
        Cart.Add(product);
    }

    public void AddProductsToCart(params Product[] products) =>
        products.ForEach(product =>
        {
            try
            {
                AddProduct(product);
            }
            catch (Exception e) when (e is UnderAgeException or ExpiredProductException)
            {
                Console.WriteLine(e.Message);
            }
        });

    public void AddProductsToCart(Product product, int amount) =>
        AddProductsToCart(Enumerable.Range(0, amount).Select(_ => product).ToArray());

    public override string ToString()
    {
        var delimiter = string.Format(" |\n| {0, 15} | {0, 5} | {0, 5} | {0, 20} | {0, 20} | ", "");
        var cartProducts = Cart
            .GroupBy(product => product)
            .Select(productGroup => FormatCartProduct(productGroup.Key, productGroup.Count()));
        if (Cart.Any()) cartProducts = cartProducts.Append(FormatTotal(Cart.Select(product => product.Price).Sum()));
        var cartInfo = string.Join(delimiter, cartProducts.DefaultIfEmpty("EMPTY").Select(info => $"{info,-80}"));

        return $"| {FullName,-15} | {Age,-5} | {Sex,-5} | {(HasDiscountCard ? "YES" : "NO"),-20} |" +
               $" {PersonalDiscount,-20:P0} | {cartInfo} |";
    }

    private static string FormatCartProduct(Product product, int amount) =>
        $"{product.ToStringExt()} - {amount}x - {amount * product.Price:C2};";

    private string FormatTotal(double sum) =>
        $"TOTAL - {sum:C2} - DISCOUNT - {PersonalDiscount:P0} - {sum - sum * PersonalDiscount:C2}";

    private void ValidateAgeAvailability(Product product)
    {
        if (Age < 18 && product is Drink { IsAlcohol: true })
            throw new UnderAgeException(FullName, product.Name);
    }

    private void ValidateExpirationDate(Product product)
    {
        if (product.ExpirationDate < DateTime.Today)
            throw new ExpiredProductException(FullName, product.Name, product.ExpirationDate);
    }

    private bool Equals(Customer other) => Id.Equals(other.Id);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((Customer)obj);
    }

    public override int GetHashCode() => Id.GetHashCode();
}