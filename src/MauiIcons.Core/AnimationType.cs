namespace MauiIcons.Core;

/// <summary>
/// Defines the types of animations that can be applied to icons in the MauiIcons library.
/// </summary>
/// <remarks>
/// This enum is used to specify the animation behavior for icons, allowing developers to easily apply common animations such as spinning, pulsing, shaking, or rotating.
/// The 'None' option indicates that no animation should be applied.</remarks>
public enum AnimationType
{
	/// <summary>
	/// Represents the absence of an animation. When this value is used, the icon will not have any animation applied to it.
	/// </summary>
	None,
	/// <summary>
	/// Represents a spin operation or state, typically used to indicate ongoing processing or waiting.
	/// </summary>
    Spin,
	/// <summary>
	/// Represents a pulse or signal, typically used to indicate a discrete event or state change.
	/// </summary>
    Pulse,
	/// <summary>
	/// Represents a shake effect or operation.
	/// </summary>
    Shake,
	/// <summary>
	/// Represents a simple, one-time rotation operation.
	/// </summary>
    Rotate
}
