using MauiIcons.Core.Helpers;

namespace MauiIcons.Material.Sharp;

/// <summary>
/// Extension methods for configuring Material Sharp icons in a .NET MAUI application.
/// </summary>
public static class BuilderExtensions
{
    private const string FontFileName = "material-sharp.otf";

    /// <summary>
    /// Adds Material Sharp icon font to the application.
    /// </summary>
    /// <param name="builder">The <see cref="MauiAppBuilder"/> to configure.</param>
    /// <returns>The <see cref="MauiAppBuilder"/> for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the embedded font resource is not found in the assembly.</exception>
    public static MauiAppBuilder UseMaterialSharp(this MauiAppBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder.ConfigureFonts(fonts =>
        {
            FontRegistrationHelper.RegisterEmbeddedFont(
                fonts,
                typeof(BuilderExtensions).Assembly,
                FontFileName,
                MaterialSharpFont.FontAlias);
        });
    }
}