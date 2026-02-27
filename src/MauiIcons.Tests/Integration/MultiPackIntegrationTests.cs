using MauiIcons.FontAwesome.Brands;
using MauiIcons.FontAwesome.Regular;
using MauiIcons.FontAwesome.Solid;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Regular;
using MauiIcons.Material.Round;
using MauiIcons.Material.Sharp;
using MauiIcons.Material.TwoTone;
using MauiIcons.MaterialSymbols.Outlined;
using MauiIcons.MaterialSymbols.Rounded;
using MauiIcons.MaterialSymbols.Sharp;
using System.Reflection;

namespace MauiIcons.Tests.Integration;

/// <summary>
/// Tests d'intégration qui vérifient le bon fonctionnement de plusieurs packs ensemble
/// </summary>
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

        // Vérifie qu'il y a autant de namespaces uniques que de packs
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

        // Vérifie qu'il y a autant de FontFamily uniques que de packs
        Assert.Equal(11, fontFamilies.Count);
    }

    [Fact]
    public void GetEnumByGlyph_WorksAcrossDifferentPacks()
    {
        // Test de round-trip pour chaque pack
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
