namespace MauiIcons.Material.Regular;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseMaterialRegular(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "material-regular.ttf", nameof(MaterialRegularIcons));
        });
    }
}