using MauiIcons.FontAwesome.Brands.Icons;
using MauiIcons.FontAwesome.Brands.Controls;
using MauiIcons.FontAwesome.Brands.Extensions;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeBrandsTests : BaseIconPackTests<
    FontAwesomeBrandsIcons,
    FontAwesomeBrandsIcon,
    FontAwesomeBrandsExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
		// Security test on a known icon
		Assert.Equal("\uf17b", FontAwesomeBrandsIcons.Android.GetGlyph());
    }
}