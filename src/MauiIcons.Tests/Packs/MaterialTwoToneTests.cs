using MauiIcons.Material.TwoTone.Icons;
using MauiIcons.Material.TwoTone.Controls;
using MauiIcons.Material.TwoTone.Extensions;

namespace MauiIcons.Tests.Packs;

public class MaterialTwoToneTests : BaseIconPackTests<
    MaterialTwoToneIcons,
    MaterialTwoToneIcon,
    MaterialTwoToneExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        Assert.Equal("\ue06f", MaterialTwoToneIcons.Note.GetGlyph());
    }
}