using System.Text;
using System.Text.Json;

namespace GroceryStore.Core.Helpers;

public static class JsonHelper
{
    public static ICollection<T> GetData<T>(string filePath)
    {
        var jsonFromFile = File.ReadAllText(filePath);
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<ICollection<T>>(jsonFromFile, serializerOptions);
    }

    public static void SetData<T>(ICollection<T> objects, string filePath)
    {
        var fullFilePath =
            "C:\\Users\\GoNzO\\RiderProjects\\Grocery_Store_CSharp_Programming_Project\\GroceryStore.Models\\" +
            filePath; //TODO fix path
        var serializerOptions = new JsonSerializerOptions
            { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
        var serializedCollection = JsonSerializer.Serialize(objects, serializerOptions);
        File.WriteAllText(fullFilePath, serializedCollection, Encoding.UTF8);
    }
}