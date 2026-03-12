using MauiIcons.Material.Outlined.Icons;
using MauiIcons.Material.Outlined.Controls;
using MauiIcons.Material.Outlined.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialOutlinedTests : BaseIconPackTests<
    MaterialOutlinedIcons,
    MaterialOutlinedIcon,
    MaterialOutlinedExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue85b", MaterialOutlinedIcons.AspectRatio.GetGlyph());
    }
}