namespace MauiIcons.Core;

public class IconPlatformExtension<TEnum> : IMarkupExtension<TEnum>
    where TEnum : struct, Enum
{
    public TEnum Android { get; set; }
    public TEnum iOS { get; set; }
    public TEnum WinUI { get; set; }
    public TEnum MacCatalyst { get; set; }

    public TEnum ProvideValue(IServiceProvider serviceProvider)
    {
        // Détecte la plateforme au runtime
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

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        => ProvideValue(serviceProvider);
}
