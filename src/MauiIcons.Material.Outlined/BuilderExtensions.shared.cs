namespace MauiIcons.Material.Outlined;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseMaterialOutlined(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "material-outlined.otf", MaterialOutlinedFont.FontAlias);
        });
    }
}