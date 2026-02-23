namespace MauiIcons.Core.Attributes;

[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public sealed class IconFontAttribute(string fontFamily) : Attribute
{
    public string FontFamily { get; } = fontFamily;
}
