using MauiIcons.Material.Sharp.Icons;
using MauiIcons.Material.Sharp.Controls;
using MauiIcons.Material.Sharp.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialSharpTests : BaseIconPackTests<
    MaterialSharpIcons,
    MaterialSharpIcon,
    MaterialSharpExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue99a", MaterialSharpIcons.Dangerous.GetGlyph());
    }
}