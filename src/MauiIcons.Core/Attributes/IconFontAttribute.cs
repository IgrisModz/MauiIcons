namespace MauiIcons.Core.Attributes;

/// <summary>
/// Specifies the font family to use when rendering icons for an enumeration.
/// </summary>
/// <remarks>Apply this attribute to an enumeration to associate it with a specific icon font family. This enables
/// consumers to determine the appropriate font when displaying icons represented by the enum values.</remarks>
/// <param name="fontFamily">The name of the font family to use for text rendering. Cannot be null or empty.</param>
[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public sealed class IconFontAttribute(string fontFamily) : Attribute
{
    /// <summary>
    /// Gets the name of the font family used for text rendering.
    /// </summary>
    public string FontFamily { get; } = fontFamily;
}
