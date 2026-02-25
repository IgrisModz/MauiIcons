using MauiIcons.FontAwesome.Brands;

namespace MauiIcons.Tests.Core;

public class EnumExtensionTests
{
    [Theory]
    [InlineData(DummyIcon.Home, "\ue000")]
    [InlineData(DummyIcon.Settings, "\ue001")]
    public void GetGlyph_Returns_Expected_Value(DummyIcon icon, string expected)
    {
        var result = icon.GetGlyph();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetEnumByGlyph_WithValidGlyph_ReturnsCorrectEnum()
    {
        var glyph = "\uf17b";
        var result = glyph.GetEnumByGlyph<FontAwesomeBrandsIcons>();

        Assert.NotNull(result);
        Assert.Equal(FontAwesomeBrandsIcons.Android, result.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\uffff")]
    public void GetEnumByGlyph_WithInvalidInput_ReturnsNull(string? glyph)
    {
        var result = glyph.GetEnumByGlyph<FontAwesomeBrandsIcons>();

        Assert.Null(result);
    }

    [Fact]
    public void GetEnumByGlyph_RoundTrip_ShouldBeConsistent()
    {
        var originalEnum = FontAwesomeBrandsIcons.Facebook;
        var glyph = originalEnum.GetGlyph();
        var result = glyph.GetEnumByGlyph<FontAwesomeBrandsIcons>();

        Assert.NotNull(result);
        Assert.Equal(originalEnum, result.Value);
    }

    [Fact]
    public void GetFontFamily_WithIconFontAttribute_ReturnsAttributeValue()
    {
        var fontFamily = FontAwesomeBrandsIcons.Android.GetFontFamily();

        Assert.NotNull(fontFamily);
        Assert.NotEmpty(fontFamily);
        Assert.Equal("FontAwesomeBrands", fontFamily);
    }

    [Fact]
    public void GetFontFamily_IsCached()
    {
        // Premier appel
        var fontFamily1 = FontAwesomeBrandsIcons.Android.GetFontFamily();

        // Deuxième appel (devrait utiliser le cache)
        var fontFamily2 = FontAwesomeBrandsIcons.Apple.GetFontFamily();

        Assert.Equal(fontFamily1, fontFamily2);
    }

    [Fact]
    public void GetEnumByGlyph_AllEnumValues_CanBeRetrieved()
    {
        // Test avec un échantillon pour éviter que le test soit trop long
        var sampleIcons = new[]
        {
            FontAwesomeBrandsIcons.Android,
            FontAwesomeBrandsIcons.Apple,
            FontAwesomeBrandsIcons.Facebook,
            FontAwesomeBrandsIcons.Google,
            FontAwesomeBrandsIcons.Twitter
        };

        foreach (var icon in sampleIcons)
        {
            var glyph = icon.GetGlyph();
            var retrieved = glyph.GetEnumByGlyph<FontAwesomeBrandsIcons>();

            Assert.NotNull(retrieved);
            Assert.Equal(icon, retrieved.Value);
        }
    }
}
