using MauiIcons.FontAwesome.Solid;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeSolidTests : BaseIconPackTests<
    FontAwesomeSolidIcons,
    FontAwesomeSolidIcon,
    FontAwesomeSolidExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uf55e", FontAwesomeSolidIcons.BusSimple.GetDescription());
    }
}