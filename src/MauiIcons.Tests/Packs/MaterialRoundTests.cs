using MauiIcons.Material.Round.Icons;
using MauiIcons.Material.Round.Controls;
using MauiIcons.Material.Round.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialRoundTests : BaseIconPackTests<
    MaterialRoundIcons,
    MaterialRoundIcon,
    MaterialRoundExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue39f", MaterialRoundIcons.Assistant.GetGlyph());
    }
}