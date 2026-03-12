using System.Reflection;
using MauiIcons.Core.Attributes;

namespace MauiIcons.Tests.Shared;

public abstract class BaseIconPackTests<TEnum, TControl, TExtension>
    where TEnum : struct, Enum
    where TControl : BaseIcon<TEnum>, new()
    where TExtension : IconExtension<TEnum>, new()
{
    [Fact]
    public void Enum_Should_Have_IconFont_Attribute()
    {
        var iconFontAttribute = typeof(TEnum).GetCustomAttribute<IconFontAttribute>();

        Assert.NotNull(iconFontAttribute);
        Assert.NotNull(iconFontAttribute.FontFamily);
        Assert.NotEmpty(iconFontAttribute.FontFamily);
    }

    [Fact]
    public void All_Enum_Values_Should_Have_Valid_Unicode_Glyph()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var glyph = icon.GetGlyph();

            Assert.NotNull(glyph);
            Assert.NotEmpty(glyph);
        }
    }

    [Fact]
    public void Enum_Should_Have_At_Least_One_Value()
    {
        var values = Enum.GetValues<TEnum>();
        Assert.NotEmpty(values);
    }

    [Fact]
    public void All_Enum_Values_Should_Have_Valid_Names()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var name = icon.ToString();

            Assert.NotNull(name);
            Assert.NotEmpty(name);
            Assert.DoesNotContain(" ", name); // No spaces in names
			Assert.Matches("^[A-Za-z0-9_]+$", name); // Only alphanumeric characters and underscores
		}
    }

    [Fact]
    public void GetGlyph_Should_Return_Single_Character_Or_Surrogate_Pair()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var glyph = icon.GetGlyph();

			// A valid Unicode glyph should have 1 or 2 characters (substitution pair)
			Assert.InRange(glyph.Length, 1, 2);
        }
    }
}
