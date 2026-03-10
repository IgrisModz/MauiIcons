using MauiIcons.Core.Attributes;
using System.Collections.Concurrent;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

/// <summary>
/// Provides extension methods for working with enumeration types that represent Unicode glyphs or icon fonts.
/// </summary>
/// <remarks>This static class includes methods for converting enumeration values to Unicode glyph characters,
/// retrieving enumeration values from glyph strings, and obtaining font family names associated with icon font
/// enumerations. These methods are intended for use with enums that represent icon sets or symbol fonts, and rely on
/// conventions or custom attributes to map between enum values and their visual representations.</remarks>
public static class EnumExtension
{
    static readonly ConcurrentDictionary<Type, string> fontFamilyCache = new();
    static readonly ConcurrentDictionary<Type, Dictionary<string, Enum>> glyphReverseCache = new();

    /// Return the glyph string corresponding to the enum value, by converting its integer value to a Unicode character.
    /// <summary>
    /// Converts the specified enumeration value to its corresponding Unicode glyph character.Return the glyph string corresponding to the enum value, by converting its integer value to a Unicode character.
    /// </summary>
    /// <remarks>This method is typically used with enums that represent Unicode code points, such as icon or
    /// symbol sets. The method converts the enum value to its integer representation and then to the corresponding
    /// Unicode character. If the enum value does not represent a valid Unicode code point, the result may not be a
    /// valid character.</remarks>
    /// <typeparam name="TEnum">The enumeration type whose value will be converted to a Unicode character. Must be an enum type.</typeparam>
    /// <param name="icon">The enumeration value to convert to a Unicode glyph.</param>
    /// <returns>A string containing the Unicode character that corresponds to the integer value of the specified enumeration.</returns>int = Convert.ToInt32((Enum)(object)icon);
    public static string GetGlyph<TEnum>(this TEnum icon) where TEnum : struct, Enum
    {
        int codePoint = Convert.ToInt32((Enum)(object)icon);
        return char.ConvertFromUtf32(codePoint);
    }

    /// <summary>
    /// Retrieves the enumeration value of type TEnum that corresponds to the specified glyph string, if one exists.
    /// </summary>
    /// <remarks>This method uses a cached mapping between glyph strings and enumeration values for improved
    /// performance on repeated calls. The mapping relies on the GetGlyph extension method for TEnum values. If multiple
    /// enumeration values share the same glyph, the behavior is undefined.</remarks>
    /// <typeparam name="TEnum">The enumeration type to search for a matching value. Must be a struct that implements Enum.</typeparam>
    /// <param name="glyph">The glyph string to match against the enumeration values. Can be null or whitespace.</param>
    /// <returns>A nullable TEnum value that matches the specified glyph; otherwise, null if no match is found or if glyph is
    /// null or whitespace.</returns>
    public static TEnum? GetEnumByGlyph<TEnum>(this string? glyph) where TEnum : struct, Enum
    {
		if (string.IsNullOrWhiteSpace(glyph))
		{
			return null;
		}

        var type = typeof(TEnum);

        var map = glyphReverseCache.GetOrAdd(type, t =>
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
    /// Gets the font family name associated with the specified icon font enumeration type.
    /// </summary>
    /// <remarks>This method uses a cache to improve performance when retrieving font family names for
    /// enumeration types. The method relies on the presence of an IconFontAttribute on the enumeration type to
    /// determine the font family; otherwise, it falls back to a naming convention.</remarks>
    /// <typeparam name="TEnum">The enumeration type representing a set of icon glyphs. Must be a value type that implements Enum.</typeparam>
    /// <param name="_">An instance of the icon font enumeration. The value is ignored; only the type is used.</param>
    /// <returns>The font family name as a string for the specified icon font enumeration type. If the enumeration type is not
    /// decorated with an IconFontAttribute, the type name with the 'Icons' suffix removed is returned.</returns>
    public static string GetFontFamily<TEnum>(this TEnum _)
        where TEnum : struct, Enum
    {
        var type = typeof(TEnum);

        return fontFamilyCache.GetOrAdd(type, t =>
        {
            var attr = t.GetCustomAttribute<IconFontAttribute>();
            return attr?.FontFamily ?? t.Name[..^"Icons".Length];
        });
    }
}
