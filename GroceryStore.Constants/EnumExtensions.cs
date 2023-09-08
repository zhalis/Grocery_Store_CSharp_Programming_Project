using System.ComponentModel;
using System.Reflection;

namespace GroceryStore.Constants;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        return value.GetType()
            .GetMember(value.ToString())[0]
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description;
    }
}