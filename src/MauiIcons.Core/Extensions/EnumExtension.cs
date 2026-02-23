using MauiIcons.Core.Attributes;
using System.Collections.Concurrent;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

public static class EnumExtension
{
    private static readonly ConcurrentDictionary<Type, string> _fontFamilyCache = new();
    private static readonly ConcurrentDictionary<Type, Dictionary<string, Enum>> _glyphReverseCache = new();

    /// Return the glyph string corresponding to the enum value, by converting its integer value to a Unicode character.
    public static string GetGlyph<TEnum>(this TEnum icon) where TEnum : struct, Enum
    {
        int codePoint = Convert.ToInt32((Enum)(object)icon);
        return char.ConvertFromUtf32(codePoint);
    }

    /// <summary>
    /// Return the enum value of type TEnum that corresponds to the given glyph string, or null if no match is found.
    /// </summary>
    public static TEnum? GetEnumByGlyph<TEnum>(this string? glyph) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(glyph)) return null;

        var type = typeof(TEnum);

        var map = _glyphReverseCache.GetOrAdd(type, t =>
        {
            var dict = new Dictionary<string, Enum>();
            foreach (TEnum enumValue in Enum.GetValues(t))
            {
                dict[enumValue.GetGlyph()] = enumValue;
            }
            return dict;
        });

        return map.TryGetValue(glyph, out var enumValue) ? (TEnum)enumValue : null;
    }

    /// <summary>
    /// Return the font family name associated with the enum type, either from the IconFontAttribute or the enum type name itself.
    /// </summary>
    public static string GetFontFamily<TEnum>(this TEnum _)
        where TEnum : struct, Enum
    {
        var type = typeof(TEnum);

        return _fontFamilyCache.GetOrAdd(type, t =>
        {
            var attr = t.GetCustomAttribute<IconFontAttribute>();
            return attr?.FontFamily ?? t.Name[..^"Icons".Length];
        });
    }
}
