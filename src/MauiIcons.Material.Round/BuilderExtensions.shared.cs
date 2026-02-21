namespace MauiIcons.Material.Round;

public static class BuilderExtensions
{
    public static MauiAppBuilder UseMaterialRound(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, "material-round.otf", nameof(MaterialRoundIcons));
        });
    }
}