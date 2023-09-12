namespace GroceryStore.Core.Helpers;

public static class CollectionHelper
{
    private const string CustomersFilePath = "Resources/customers.json";
    private const string ProductsFilePath = "Resources/products.json";
    
    public static void AddCustomer<T>(this ICollection<T> source, T customer) => 
        AddElement(source, customer, CustomersFilePath);

    public static void AddProduct<T>(this ICollection<T> source, T product) => 
        AddElement(source, product, ProductsFilePath);

    private static void AddElement<T>(this ICollection<T> source, T element, string path)
    {
        source.Add(element);
        JsonHelper.SetData(source, path);
    }
}