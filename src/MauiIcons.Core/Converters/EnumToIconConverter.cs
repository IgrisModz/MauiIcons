using MauiIcons.Core.Extensions;
using System.Globalization;

namespace MauiIcons.Core.Converters;

/// <summary>
/// Provides a value converter that maps enumeration values to their associated glyph representations and vice versa for
/// use in data binding scenarios.
/// </summary>
/// <remarks>This converter is typically used in WPF or XAML-based applications to display icons or glyphs
/// corresponding to enum values in the user interface. It relies on extension methods such as EnumExtension.GetGlyph
/// and EnumExtension.GetEnumByGlyph to perform the conversions. The converter returns null if the input value or target
/// type does not meet the expected criteria (i.e., not an enum or not a string).</remarks>
public class EnumToIconConverter : IValueConverter
{

    /// <summary>
    /// Converts an enumeration value to its associated glyph representation using the specified culture.
    /// </summary>
    /// <remarks>If the input value is not an enumeration, the method returns null. The conversion relies on
    /// the EnumExtension.GetGlyph method, which must be available for the enumeration type.</remarks>
    /// <param name="value">The value to convert. Must be an enumeration value or null.</param>
    /// <param name="targetType">The type to convert the value to. This parameter is not used in this implementation.</param>
    /// <param name="parameter">An optional parameter to be used in the conversion. This parameter is not used in this implementation.</param>
    /// <param name="culture">The culture to use in the converter. This parameter is not used in this implementation.</param>
    /// <returns>A glyph object representing the enumeration value if the input is an enumeration; otherwise, null.</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null && value.GetType().IsEnum)
        {
            var method = typeof(EnumExtension).GetMethod(nameof(EnumExtension.GetGlyph))
                ?.MakeGenericMethod(value.GetType());
            return method?.Invoke(null, [value]);
        }
        return null;
    }

    /// <summary>
    /// Converts a string representation of an enum glyph back to its corresponding enum value.
    /// </summary>
    /// <remarks>If the target type is not an enum or the value is not a string, the method returns null. The
    /// conversion relies on the EnumExtension.GetEnumByGlyph method, which must support the target enum type.</remarks>
    /// <param name="value">The value to convert back. Expected to be a string representing an enum glyph, or null.</param>
    /// <param name="targetType">The type of the enum to convert to. Must be an enumeration type.</param>
    /// <param name="parameter">An optional parameter to be used in the conversion. This parameter is not used in this implementation.</param>
    /// <param name="culture">The culture to use in the conversion. This parameter is not used in this implementation.</param>
    /// <returns>The enum value corresponding to the provided glyph string if conversion is successful; otherwise, null.</returns>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string str && targetType.IsEnum)
        {
            var method = typeof(EnumExtension).GetMethod(nameof(EnumExtension.GetEnumByGlyph))
                ?.MakeGenericMethod(targetType);
            return method?.Invoke(null, [str]);
        }
        return null;
    }
}
