namespace MauiIcons.Material.TwoTone;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseMaterialTwoTone(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "material-twotone.otf", nameof(MaterialTwoToneIcons));
        });
    }
}