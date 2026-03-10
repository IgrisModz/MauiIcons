namespace MauiIcons.Core;

/// <summary>
/// Defines the types of animations that can be applied to icons in the MauiIcons library.
/// </summary>
/// <remarks>
/// This enum is used to specify the animation behavior for icons, allowing developers to easily apply common animations such as spinning, pulsing, shaking, or rotating. The 'None' option indicates that no animation should be applied.
/// </remarks>
public enum AnimationType
{
    None,
    Spin,   // Infinite rotation (e.g., spinner)
    Pulse,  // Grows and shrinks
    Shake,  // Lateral tremor
    Rotate  // Simple rotation, one time only
}
