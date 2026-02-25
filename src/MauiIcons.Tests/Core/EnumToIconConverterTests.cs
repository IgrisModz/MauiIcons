using MauiIcons.Core.Converters;
using MauiIcons.FontAwesome.Brands;

namespace MauiIcons.Tests.Core;

public class EnumToIconConverterTests
{
    private readonly EnumToIconConverter _converter = new();

    [Fact]
    public void Convert_WithValidEnum_ReturnsGlyph()
    {
        var result = _converter.Convert(FontAwesomeBrandsIcons.Android, typeof(string), null, null);

        Assert.Equal("\uf17b", result);
    }

    [Fact]
    public void Convert_WithNull_ReturnsNull()
    {
        var result = _converter.Convert(null, typeof(string), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void Convert_WithNonEnum_ReturnsNull()
    {
        var result = _converter.Convert("not an enum", typeof(string), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void Convert_WithIntValue_ReturnsNull()
    {
        var result = _converter.Convert(42, typeof(string), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithValidGlyph_ReturnsEnum()
    {
        var result = _converter.ConvertBack("\uf17b", typeof(FontAwesomeBrandsIcons), null, null);

        Assert.NotNull(result);
        Assert.IsType<FontAwesomeBrandsIcons>(result);
        Assert.Equal(FontAwesomeBrandsIcons.Android, result);
    }

    [Fact]
    public void ConvertBack_WithNullGlyph_ReturnsNull()
    {
        var result = _converter.ConvertBack(null, typeof(FontAwesomeBrandsIcons), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithEmptyString_ReturnsNull()
    {
        var result = _converter.ConvertBack("", typeof(FontAwesomeBrandsIcons), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithWhitespaceString_ReturnsNull()
    {
        var result = _converter.ConvertBack("   ", typeof(FontAwesomeBrandsIcons), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithInvalidGlyph_ReturnsNull()
    {
        var result = _converter.ConvertBack("\uffff", typeof(FontAwesomeBrandsIcons), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithNonEnumTargetType_ReturnsNull()
    {
        var result = _converter.ConvertBack("\uf17b", typeof(string), null, null);

        Assert.Null(result);
    }

    [Fact]
    public void ConvertBack_WithNonStringValue_ReturnsNull()
    {
        var result = _converter.ConvertBack(42, typeof(FontAwesomeBrandsIcons), null, null);

        Assert.Null(result);
    }
}
