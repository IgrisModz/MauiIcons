using MauiIcons.Material.Regular.Icons;
using MauiIcons.Material.Regular.Controls;
using MauiIcons.Material.Regular.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialRegularTests : BaseIconPackTests<
    MaterialRegularIcons,
    MaterialRegularIcon,
    MaterialRegularExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue859", MaterialRegularIcons.Android.GetGlyph());
    }
}