namespace GroceryStore.Models;

public class Customer
{
    private readonly List<Product> _cart = new();
    private string _firstName;
    private string _lastName;
    private string FullName => $"{_firstName} {_lastName}";
    private int _age;
    private Sex _sex;
    private bool _hasDiscountCard;
    private double _personalDiscount;

    public Customer(string firstName, string lastName, int age, Sex sex, bool hasDiscountCard,
        double personalDiscount = 0)
    {
        _age = age;
        _sex = sex;
        _firstName = firstName;
        _lastName = lastName;
        UpdateDiscountCardAndPersonalDiscount(hasDiscountCard, personalDiscount);
    }

    public void UpdateDiscountCardAndPersonalDiscount(bool hasDiscountCard, double personalDiscount = 0)
    {
        _hasDiscountCard = hasDiscountCard;
        _personalDiscount = hasDiscountCard ? personalDiscount : 0;
    }

    public void UpdateFirstAndLastNames(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public void AddProductsToCart(params Product[] products) => _cart.AddRange(products);

    public void AddProductsToCart(Product product, int amount)
    {
        for (var i = 0; i < amount; i++) _cart.Add(product);
    }

    public string GetCustomerInfo()
    {
        var delimiter = string.Format(" |\n| {0, 15} | {0, 5} | {0, 5} | {0, 20} | {0, 20} | ", "");
        var cartProducts = _cart
            .GroupBy(product => product)
            .Select(productGroup => FormatCartProduct(productGroup.Key, productGroup.Count()));
        if (_cart.Any()) cartProducts = cartProducts.Append(FormatTotal(_cart.Select(product => product.Price).Sum()));
        var cartInfo = string.Join(delimiter, cartProducts.DefaultIfEmpty("EMPTY").Select(info => $"{info,-60}"));
        
        return $"| {FullName,-15} | {_age,-5} | {_sex,-5} | {(_hasDiscountCard ? "YES" : "NO"),-20} |" +
               $" {_personalDiscount,-20:P0} | {cartInfo} |";
    }

    private static string FormatCartProduct(Product product, int amount) =>
        $"{product.GetProductInfo()} - {amount}x - {amount * product.Price:C2};";

    private string FormatTotal(double sum) =>
        $"TOTAL - {sum:C2} - DISCOUNT - {_personalDiscount:P0} - {sum - sum * _personalDiscount:C2}";
}