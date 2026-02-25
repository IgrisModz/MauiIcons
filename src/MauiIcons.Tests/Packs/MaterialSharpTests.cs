using MauiIcons.Material.Sharp;

namespace MauiIcons.Tests.Packs;

public class MaterialSharpTests : BaseIconPackTests<
    MaterialSharpIcons,
    MaterialSharpIcon,
    MaterialSharpExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uE99A", MaterialSharpIcons.Dangerous.GetGlyph());
    }
}