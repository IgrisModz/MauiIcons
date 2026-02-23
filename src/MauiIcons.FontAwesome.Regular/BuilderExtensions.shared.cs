namespace MauiIcons.FontAwesome.Regular;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseFontAwesomeRegular(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "fa-regular-400.otf", FontAwesomeRegularFont.FontAlias);
        });
    }
}