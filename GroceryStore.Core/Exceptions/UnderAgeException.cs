namespace GroceryStore.Core.Exceptions;

public class UnderAgeException : Exception
{
    public UnderAgeException(string customerName, string productName)
        : base($"Customer {customerName} is unable to buy the following products: " +
               $"{productName} according to age restrictions")
    {
    }
}