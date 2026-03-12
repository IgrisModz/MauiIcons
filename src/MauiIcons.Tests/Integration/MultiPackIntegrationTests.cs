using MauiIcons.FontAwesome.Brands.Icons;
using MauiIcons.FontAwesome.Regular.Icons;
using MauiIcons.FontAwesome.Solid.Icons;
using MauiIcons.Material.Outlined.Icons;
using MauiIcons.Material.Regular.Icons;
using MauiIcons.Material.Round.Icons;
using MauiIcons.Material.Sharp.Icons;
using MauiIcons.Material.TwoTone.Icons;
using MauiIcons.MaterialSymbols.Outlined.Icons;
using MauiIcons.MaterialSymbols.Rounded.Icons;
using MauiIcons.MaterialSymbols.Sharp.Icons;
using System.Reflection;

namespace MauiIcons.Tests.Integration;

/// <summary>
/// Provides a suite of integration tests to validate consistency and interoperability between multiple icon packs in the application.
/// </summary>
/// <remarks>These tests verify that each icon pack has a unique namespace
/// and font family, and that the conversion between glyphs and enumerations works correctly for each pack.
/// They also ensure that the metadata attributes associated with icon enumerations meet expectations. This class is designed to guarantee the integrity of
/// multi-pack integration and prevent conflicts or inconsistencies when adding or modifying icon packs.</remarks>
public class MultiPackIntegrationTests
{
    [Fact]
    public void AllPacks_ShouldHaveUniqueNamespaces()
    {
        var namespaces = new HashSet<string>
        {
            typeof(FontAwesomeBrandsIcons).Namespace!,
            typeof(FontAwesomeRegularIcons).Namespace!,
            typeof(FontAwesomeSolidIcons).Namespace!,
            typeof(MaterialOutlinedIcons).Namespace!,
            typeof(MaterialRegularIcons).Namespace!,
            typeof(MaterialRoundIcons).Namespace!,
            typeof(MaterialSharpIcons).Namespace!,
            typeof(MaterialTwoToneIcons).Namespace!,
            typeof(MaterialSymbolsOutlinedIcons).Namespace!,
            typeof(MaterialSymbolsRoundedIcons).Namespace!,
            typeof(MaterialSymbolsSharpIcons).Namespace!
        };

		// Verify that there are as many unique namespaces as there are packages.
		Assert.Equal(11, namespaces.Count);
    }

    [Fact]
    public void AllPacks_ShouldHaveUniqueFontFamilies()
    {
        var fontFamilies = new HashSet<string>
        {
            FontAwesomeBrandsIcons.Android.GetFontFamily(),
            FontAwesomeRegularIcons.Bell.GetFontFamily(),
            FontAwesomeSolidIcons.House.GetFontFamily(),
            MaterialOutlinedIcons.Home.GetFontFamily(),
            MaterialRegularIcons.Home.GetFontFamily(),
            MaterialRoundIcons.Home.GetFontFamily(),
            MaterialSharpIcons.Home.GetFontFamily(),
            MaterialTwoToneIcons.Home.GetFontFamily(),
            MaterialSymbolsOutlinedIcons.Home.GetFontFamily(),
            MaterialSymbolsRoundedIcons.Home.GetFontFamily(),
            MaterialSymbolsSharpIcons.Home.GetFontFamily()
        };

		// Verify that there are as many unique FontFamily as there are packs.
		Assert.Equal(11, fontFamilies.Count);
    }

    [Fact]
    public void GetEnumByGlyph_WorksAcrossDifferentPacks()
    {
		// Round-trip test for each pack
		var brands = FontAwesomeBrandsIcons.Android.GetGlyph()
            .GetEnumByGlyph<FontAwesomeBrandsIcons>();

        var regular = FontAwesomeRegularIcons.Bell.GetGlyph()
            .GetEnumByGlyph<FontAwesomeRegularIcons>();

        var solid = FontAwesomeSolidIcons.House.GetGlyph()
            .GetEnumByGlyph<FontAwesomeSolidIcons>();

        var materialOutlined = MaterialOutlinedIcons.Home.GetGlyph()
            .GetEnumByGlyph<MaterialOutlinedIcons>();

        var materialSymbolsOutlined = MaterialSymbolsOutlinedIcons.Home.GetGlyph()
            .GetEnumByGlyph<MaterialSymbolsOutlinedIcons>();

        Assert.Equal(FontAwesomeBrandsIcons.Android, brands);
        Assert.Equal(FontAwesomeRegularIcons.Bell, regular);
        Assert.Equal(FontAwesomeSolidIcons.House, solid);
        Assert.Equal(MaterialOutlinedIcons.Home, materialOutlined);
        Assert.Equal(MaterialSymbolsOutlinedIcons.Home, materialSymbolsOutlined);
    }

    [Theory]
    [InlineData(typeof(FontAwesomeBrandsIcons), "FontAwesomeBrands")]
    [InlineData(typeof(FontAwesomeRegularIcons), "FontAwesomeRegular")]
    [InlineData(typeof(FontAwesomeSolidIcons), "FontAwesomeSolid")]
    [InlineData(typeof(MaterialOutlinedIcons), "MaterialOutlined")]
    [InlineData(typeof(MaterialRegularIcons), "MaterialRegular")]
    [InlineData(typeof(MaterialRoundIcons), "MaterialRound")]
    [InlineData(typeof(MaterialSharpIcons), "MaterialSharp")]
    [InlineData(typeof(MaterialTwoToneIcons), "MaterialTwoTone")]
    [InlineData(typeof(MaterialSymbolsOutlinedIcons), "MaterialSymbolsOutlined")]
    [InlineData(typeof(MaterialSymbolsRoundedIcons), "MaterialSymbolsRounded")]
    [InlineData(typeof(MaterialSymbolsSharpIcons), "MaterialSymbolsSharp")]
    public void EnumType_HasExpectedFontFamily(Type enumType, string expectedFontFamily)
    {
        var attribute = enumType.GetCustomAttribute<MauiIcons.Core.Attributes.IconFontAttribute>();
        
        Assert.NotNull(attribute);
        Assert.Equal(expectedFontFamily, attribute.FontFamily);
    }
}
