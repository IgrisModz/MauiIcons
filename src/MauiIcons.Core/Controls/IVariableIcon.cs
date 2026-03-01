namespace MauiIcons.Core.Controls;

/// <summary>
/// Defines properties for a variable icon that supports adjustable visual attributes such as weight, fill, grade, and
/// optical size.
/// </summary>
/// <remarks>Implementations of this interface allow consumers to query or manipulate the visual characteristics
/// of an icon, enabling dynamic adaptation to different design requirements or display contexts. This interface extends
/// ILabel, indicating that the icon also provides label-related functionality.</remarks>
public interface IVariableIcon : ILabel
{
    /// <summary>
    /// Gets the weight value associated with the current instance.
    /// </summary>
    int Weight { get; }

    /// <summary>
    /// Gets the current fill level or amount.
    /// </summary>
    int Fill { get; }

    /// <summary>
    /// Gets the grade associated with the current instance.
    /// </summary>
    int Grade { get; }

    /// <summary>
    /// Gets the optical size value associated with the current font or rendering context.
    /// </summary>
    /// <remarks>The optical size typically represents the intended point size for which the font is
    /// optimized. This value can influence font rendering and selection, especially in variable font scenarios where
    /// optical size axes are supported.</remarks>
    int OpticalSize { get; }
}
