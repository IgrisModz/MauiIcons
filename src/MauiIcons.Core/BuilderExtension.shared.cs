#if ANDROID
using MauiIcons.Core.Platforms.Android;
#elif WINDOWS
using MauiIcons.Core.Platforms.Windows;
#elif IOS
using MauiIcons.Core.Platforms.iOS;
#elif MACCATALYST
using MauiIcons.Core.Platforms.MacCatalyst;
#endif

namespace MauiIcons.Core;

/// <summary>
/// Provides extension methods for configuring MauiIcons support in a .NET MAUI application.
/// </summary>
public static class BuilderExtension
{
    /// <summary>
    /// Configures the application to support MauiIcons by registering the necessary icon handlers.
    /// </summary>
    /// <remarks>Call this method during application startup to enable MauiIcons support on supported
    /// platforms. This method has no effect on platforms where MauiIcons is not supported.</remarks>
    /// <param name="builder">The builder used to configure the Maui application pipeline.</param>
    /// <returns>The same MauiAppBuilder instance, enabling method chaining.</returns>
    public static MauiAppBuilder UseMauiIconsCore(this MauiAppBuilder builder)
    {
#if ANDROID || WINDOWS || IOS || MACCATALYST
         builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<Controls.IVariableIcon, VariableIconHandler>();
        });
#endif
        return builder;
    }
}