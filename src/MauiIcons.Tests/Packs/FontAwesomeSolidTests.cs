using MauiIcons.FontAwesome.Solid.Icons;
using MauiIcons.FontAwesome.Solid.Controls;
using MauiIcons.FontAwesome.Solid.Extensions;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeSolidTests : BaseIconPackTests<
    FontAwesomeSolidIcons,
    FontAwesomeSolidIcon,
    FontAwesomeSolidExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\uf55e", FontAwesomeSolidIcons.BusSimple.GetGlyph());
    }
}