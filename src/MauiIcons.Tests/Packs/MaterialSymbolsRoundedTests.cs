using MauiIcons.MaterialSymbols.Rounded.Icons;
using MauiIcons.MaterialSymbols.Rounded.Controls;
using MauiIcons.MaterialSymbols.Rounded.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsRoundedTests : BaseIconPackTests<
    MaterialSymbolsRoundedIcons,
    MaterialSymbolsRoundedIcon,
    MaterialSymbolsRoundedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\uf86f", MaterialSymbolsRoundedIcons.GalleryThumbnail.GetGlyph());
    }
}