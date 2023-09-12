namespace GroceryStore.Core.Exceptions;

public class ExpiredProductException : Exception
{
    public ExpiredProductException(string customerName, string productName, DateTime expirationDate)
        : base($"Customer {customerName} is unable to buy the following products " +
               $"{productName} according to expiry date {expirationDate:dd.MM.yyyy}")
    {
    }
}