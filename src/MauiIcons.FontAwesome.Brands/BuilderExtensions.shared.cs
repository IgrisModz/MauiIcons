namespace MauiIcons.FontAwesome.Brands;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseFontAwesomeBrands(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "fa-brands-regular-400.otf", nameof(FontAwesomeBrandsIcons));
        });
    }
}