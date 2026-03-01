using MauiIcons.MaterialSymbols.Sharp;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsSharpTests : BaseIconPackTests<
    MaterialSymbolsSharpIcons,
    MaterialSymbolsSharpIcon,
    MaterialSymbolsSharpExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uef76", MaterialSymbolsSharpIcons.Verified.GetGlyph());
    }
}