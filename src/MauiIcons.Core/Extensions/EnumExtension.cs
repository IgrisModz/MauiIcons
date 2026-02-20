using System.ComponentModel;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

public static class EnumExtension
{
    public static string GetDescription<TEnum>(this TEnum value) where TEnum : Enum
    {
        // On récupère les infos du champ de manière sécurisée
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());

        // On utilise "GetCustomAttribute" (singulier) qui est plus moderne
        var attribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();

        // Si l'attribut existe, on rend la description, sinon le nom de l'enum
        return attribute?.Description ?? value.ToString();
    }

    public static Enum? GetEnumByDescription(this string? description, Type type)
    {
        if (description is null) return default;
        if (!type.IsEnum) throw new NotSupportedException("Type must be an Enum");

        foreach (Enum enumItem in Enum.GetValues(type))
        {
            if (enumItem.GetDescription() == description)
            {
                return enumItem;
            }
        }
        return default;
    }
    public static string GetFontFamily<TEnum>(this TEnum? value) where TEnum : struct
    {
        if (value is null) return string.Empty;
        return value.GetType().Name;
    }

    public static string GetFontFamily<TEnum>(this TEnum value) where TEnum : Enum?
    {
        if (value is null) return string.Empty;
        return value.GetType().Name;
    }
}
