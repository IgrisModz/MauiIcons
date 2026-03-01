using MauiIcons.Material.TwoTone;

namespace MauiIcons.Tests.Packs;

public class MaterialTwoToneTests : BaseIconPackTests<
    MaterialTwoToneIcons,
    MaterialTwoToneIcon,
    MaterialTwoToneExtension>
{
    [Fact]
    public void Verify_Specific_Icon_Code()
    {
        // Test de sécurité sur une icône connue
        Assert.Equal("\ue06f", MaterialTwoToneIcons.Note.GetGlyph());
    }
}