namespace MauiIcons.Material.Sharp;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseMaterialSharp(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "material-sharp.otf", MaterialSharpFont.FontAlias);
        });
    }
}