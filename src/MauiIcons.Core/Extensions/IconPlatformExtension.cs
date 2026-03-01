namespace MauiIcons.Core.Extensions;

/// <summary>
/// Provides a markup extension that returns a platform-specific value of the specified enumeration type for use in
/// XAML.
/// </summary>
/// <remarks>This extension enables XAML markup to select different values based on the runtime platform,
/// simplifying cross-platform UI definitions. The returned value corresponds to the current device platform. If the
/// platform is not recognized, the Android value is used as a fallback.</remarks>
/// <typeparam name="TEnum">The enumeration type that defines the platform-specific values to be provided.</typeparam>
public class IconPlatformExtension<TEnum> : IMarkupExtension<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Gets or sets the value associated with the Android platform.
    /// </summary>
    public TEnum Android { get; set; }

    /// <summary>
    /// Gets or sets the value associated with the iOS platform.
    /// </summary>
    public TEnum iOS { get; set; }

    /// <summary>
    /// Gets or sets the value associated with the WinUI platform.
    /// </summary>
    public TEnum WinUI { get; set; }

    /// <summary>
    /// Gets or sets the value associated with the MacCatalyst platform.
    /// </summary>
    public TEnum MacCatalyst { get; set; }

    /// <summary>
    /// Returns the platform-specific value of the enumeration based on the current device platform.
    /// </summary>
    /// <remarks>This method determines the current platform at runtime and returns the associated enumeration
    /// value. If the platform is not Android, iOS, WinUI, or MacCatalyst, the Android value is returned as a
    /// fallback.</remarks>
    /// <param name="serviceProvider">An object that provides services for the markup extension. This parameter is not used in this implementation.</param>
    /// <returns>The enumeration value corresponding to the detected device platform. Returns the Android value if the platform
    /// is not recognized.</returns>
    public TEnum ProvideValue(IServiceProvider serviceProvider)
    {
        // Detects the platform at runtime
        if (DeviceInfo.Platform == DevicePlatform.Android)
            return Android;
        if (DeviceInfo.Platform == DevicePlatform.iOS)
            return iOS;
        if (DeviceInfo.Platform == DevicePlatform.WinUI)
            return WinUI;
        if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
            return MacCatalyst;

        return Android; // fallback
    }

    /// <summary>
    /// Provides the value to set on the property where the markup extension is applied.
    /// </summary>
    /// <param name="serviceProvider">An object that can provide services for the markup extension. This parameter is typically used to access
    /// contextual information about the target property or object.</param>
    /// <returns>The object to set on the property where the markup extension is applied.</returns>
    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        => ProvideValue(serviceProvider);
}
