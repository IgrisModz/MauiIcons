using MauiIcons.MaterialSymbols.Rounded;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsRoundedTests : BaseIconPackTests<
    MaterialSymbolsRoundedIcons,
    MaterialSymbolsRoundedIcon,
    MaterialSymbolsRoundedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\uf86f", MaterialSymbolsRoundedIcons.GalleryThumbnail.GetGlyph());
    }
}