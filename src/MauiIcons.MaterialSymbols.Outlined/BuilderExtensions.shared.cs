using MauiIcons.Core;
using MauiIcons.Core.Helpers;

namespace MauiIcons.MaterialSymbols.Outlined;

/// <summary>
/// Extension methods for configuring Material Symbols Outlined icons in a .NET MAUI application.
/// </summary>
public static class BuilderExtensions
{
    private const string FontFileName = "material-symbols-outlined.ttf";

    /// <summary>
    /// Adds Material Symbols Outlined icon font to the application.
    /// </summary>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> to configure.</param>
    /// <returns>The <see cref="MauiAppBuilder"/> for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the embedded font resource is not found in the assembly.</exception>
    public static MauiAppBuilder UseMaterialSymbolsOutlined(this MauiAppBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder.UseMauiIconsCore()
                      .ConfigureFonts(fonts =>
                      {
                          FontRegistrationHelper.RegisterEmbeddedFont(
                              fonts,
                              typeof(BuilderExtensions).Assembly,
                              FontFileName,
                              MaterialSymbolsOutlinedFont.FontAlias);
                      });
    }
}