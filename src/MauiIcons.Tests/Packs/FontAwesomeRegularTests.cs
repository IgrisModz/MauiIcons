using MauiIcons.FontAwesome.Regular;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeRegularTests : BaseIconPackTests<
    FontAwesomeRegularIcons,
    FontAwesomeRegularIcon,
    FontAwesomeRegularExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uf0f3", FontAwesomeRegularIcons.Bell.GetGlyph());
    }
}