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
        var serializerOptions = new JsonSerializerOptions
            { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
        var serializedCollection = JsonSerializer.Serialize(objects, serializerOptions);
        File.WriteAllText(filePath, serializedCollection, Encoding.UTF8);
    }
}