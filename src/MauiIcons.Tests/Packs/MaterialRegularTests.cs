using MauiIcons.Material.Regular;

namespace MauiIcons.Tests.Packs;

public class MaterialRegularTests : BaseIconPackTests<
    MaterialRegularIcons,
    MaterialRegularIcon,
    MaterialRegularExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uE859", MaterialRegularIcons.Android.GetGlyph());
    }
}