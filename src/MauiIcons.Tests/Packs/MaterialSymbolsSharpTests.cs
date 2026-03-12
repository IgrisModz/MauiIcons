using MauiIcons.MaterialSymbols.Sharp.Icons;
using MauiIcons.MaterialSymbols.Sharp.Controls;
using MauiIcons.MaterialSymbols.Sharp.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsSharpTests : BaseIconPackTests<
    MaterialSymbolsSharpIcons,
    MaterialSymbolsSharpIcon,
    MaterialSymbolsSharpExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\uef76", MaterialSymbolsSharpIcons.Verified.GetGlyph());
    }
}