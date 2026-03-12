using MauiIcons.FontAwesome.Regular.Icons;
using MauiIcons.FontAwesome.Regular.Controls;
using MauiIcons.FontAwesome.Regular.Extensions;

namespace MauiIcons.Tests.Packs;

public class FontAwesomeRegularTests : BaseIconPackTests<
    FontAwesomeRegularIcons,
    FontAwesomeRegularIcon,
    FontAwesomeRegularExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\uf0f3", FontAwesomeRegularIcons.Bell.GetGlyph());
    }
}