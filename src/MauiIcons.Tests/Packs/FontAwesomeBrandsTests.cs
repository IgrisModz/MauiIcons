using MauiIcons.FontAwesome.Brands;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeBrandsTests : BaseIconPackTests<
    FontAwesomeBrandsIcons,
    FontAwesomeBrandsIcon,
    FontAwesomeBrandsExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uf17b", FontAwesomeBrandsIcons.Android.GetGlyph());
    }
}