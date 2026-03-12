using MauiIcons.MaterialSymbols.Outlined.Icons;
using MauiIcons.MaterialSymbols.Outlined.Controls;
using MauiIcons.MaterialSymbols.Outlined.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialSymbolsOutlinedTests : BaseIconPackTests<
    MaterialSymbolsOutlinedIcons,
    MaterialSymbolsOutlinedIcon,
    MaterialSymbolsOutlinedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue85b", MaterialSymbolsOutlinedIcons.AspectRatio.GetGlyph());
    }
}