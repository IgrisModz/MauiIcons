using System.Globalization;

namespace MauiIcons.Tests.Core;

public class ConverterTests
{
    readonly EnumToIconConverter converter = new();

    [Fact]
    public void Convert_ShouldReturnUnicode_WhenEnumIsValid()
    {
        var result = converter.Convert(DummyIcon.Home, typeof(string), null, CultureInfo.InvariantCulture);
        Assert.Equal("\ue000", result);
    }

    [Fact]
    public void Convert_ShouldReturnNull_WhenValueIsNotEnum()
    {
        var result = converter.Convert("NotAnEnum", typeof(string), null, CultureInfo.InvariantCulture);
        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_ShouldReturnEnum_WhenUnicodeIsFound()
    {
        var result = converter.ConvertBack("\ue000", typeof(DummyIcon), null, CultureInfo.InvariantCulture);
        Assert.Equal(DummyIcon.Home, result);
    }
}