using MauiIcons.Core.Extensions;
using System.Globalization;

namespace MauiIcons.Core.Converters;

public class EnumToIconConverter : IValueConverter
{
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
