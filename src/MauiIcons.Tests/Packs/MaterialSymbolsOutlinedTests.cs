using MauiIcons.MaterialSymbols.Outlined;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsOutlinedTests : BaseIconPackTests<
    MaterialSymbolsOutlinedIcons,
    MaterialSymbolsOutlinedIcon,
    MaterialSymbolsOutlinedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\ue85b", MaterialSymbolsOutlinedIcons.AspectRatio.GetGlyph());
    }
}