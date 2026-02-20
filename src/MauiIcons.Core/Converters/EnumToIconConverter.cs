using MauiIcons.Core.Extensions;
using System.Globalization;

namespace MauiIcons.Core.Converters;

public class EnumToIconConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value is Enum icon) ? icon.GetDescription() : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value is string str) ? str.GetEnumByDescription(targetType) : null;
    }
}
