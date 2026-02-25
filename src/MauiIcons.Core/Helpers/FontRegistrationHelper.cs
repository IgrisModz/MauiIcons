using System.Reflection;

namespace MauiIcons.Core.Helpers;

/// <summary>
/// Helper class for registering embedded font resources in a MAUI application.
/// </summary>
public static class FontRegistrationHelper
{
    /// <summary>
    /// Registers an embedded font resource with validation.
    /// </summary>
    /// <param name="fonts">The font collection to add the font to.</param>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="fontFileName">The name of the font file (e.g., "fa-brands-regular-400.otf").</param>
    /// <param name="fontAlias">The alias to use for the font in XAML.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the embedded font resource is not found in the assembly.</exception>
    public static void RegisterEmbeddedFont(
        IFontCollection fonts,
        Assembly assembly,
        string fontFileName,
        string fontAlias)
    {
        ArgumentNullException.ThrowIfNull(fonts);
        ArgumentNullException.ThrowIfNull(assembly);
        ArgumentException.ThrowIfNullOrWhiteSpace(fontFileName);
        ArgumentException.ThrowIfNullOrWhiteSpace(fontAlias);

        ValidateEmbeddedResource(assembly, fontFileName);

        fonts.AddEmbeddedResourceFont(assembly, fontFileName, fontAlias);
    }

    /// <summary>
    /// Validates that the embedded font resource exists in the assembly.
    /// </summary>
    /// <param name="assembly">The assembly to check.</param>
    /// <param name="fontFileName">The name of the font file to validate.</param>
    /// <exception cref="FileNotFoundException">Thrown when the font resource is not found.</exception>
    private static void ValidateEmbeddedResource(Assembly assembly, string fontFileName)
    {
        var resourceNames = assembly.GetManifestResourceNames();

        var resourceExists = resourceNames.Any(name => 
            name.EndsWith(fontFileName, StringComparison.OrdinalIgnoreCase));

        if (!resourceExists)
        {
            var assemblyName = assembly.GetName().Name;
            var availableResources = resourceNames.Length > 0 
                ? string.Join(", ", resourceNames) 
                : "No resources found";

            throw new FileNotFoundException(
                $"The embedded font resource '{fontFileName}' was not found in assembly '{assemblyName}'. " +
                $"Available resources: {availableResources}",
                fontFileName);
        }
    }
}
