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

public static class BuilderExtension
{
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