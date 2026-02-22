namespace MauiIcons.Tests.Core;

public class EnumExtensionTests
{
    [Theory]
    [InlineData(DummyIcon.Home, "\ue000")]
    [InlineData(DummyIcon.Settings, "Settings")] // Cas où l'attr Description est absent
    public void GetDescription_Returns_Expected_Value(DummyIcon icon, string expected)
    {
        var result = icon.GetDescription();
        Assert.Equal(expected, result);
    }
}
