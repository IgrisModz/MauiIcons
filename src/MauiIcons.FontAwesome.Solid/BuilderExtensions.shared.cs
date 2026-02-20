namespace MauiIcons.FontAwesome.Solid;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseFontAwesomeSolid(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "fa-solid-900.otf", nameof(FontAwesomeSolidIcons));
        });
    }
}