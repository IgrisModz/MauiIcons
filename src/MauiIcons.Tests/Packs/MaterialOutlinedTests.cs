using MauiIcons.Material.Outlined;

namespace MauiIcons.Tests.Packs;

public class MaterialOutlinedTests : BaseIconPackTests<
    MaterialOutlinedIcons,
    MaterialOutlinedIcon,
    MaterialOutlinedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uE85B", MaterialOutlinedIcons.AspectRatio.GetGlyph());
    }
}