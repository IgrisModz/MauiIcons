using MauiIcons.Material.Round;

namespace MauiIcons.Tests.Packs;

public class MaterialRoundTests : BaseIconPackTests<
    MaterialRoundIcons,
    MaterialRoundIcon,
    MaterialRoundExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\ue39f", MaterialRoundIcons.Assistant.GetGlyph());
    }
}