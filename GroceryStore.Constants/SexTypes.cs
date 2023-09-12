using System.Text.Json.Serialization;

namespace GroceryStore.Constants;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SexTypes
{
    M,
    F
}