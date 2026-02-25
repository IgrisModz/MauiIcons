using MauiIcons.Core.Attributes;
using System.Reflection;

namespace MauiIcons.Tests.Core;

public class IconFontAttributeTests
{
    [Fact]
    public void IconFontAttribute_IsSealed()
    {
        var type = typeof(IconFontAttribute);

        Assert.True(type.IsSealed);
    }

    [Fact]
    public void IconFontAttribute_AttributeUsage_IsCorrect()
    {
        var attribute = typeof(IconFontAttribute).GetCustomAttribute<AttributeUsageAttribute>();

        Assert.NotNull(attribute);
        Assert.Equal(AttributeTargets.Enum, attribute.ValidOn);
        Assert.False(attribute.AllowMultiple);
    }

    [Fact]
    public void IconFontAttribute_Constructor_SetsFontFamily()
    {
        var attribute = new IconFontAttribute("TestFont");

        Assert.Equal("TestFont", attribute.FontFamily);
    }
}
