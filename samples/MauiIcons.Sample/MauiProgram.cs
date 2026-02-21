using MauiIcons.FontAwesome.Regular;
using MauiIcons.FontAwesome.Brands;
using MauiIcons.FontAwesome.Solid;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Regular;
using MauiIcons.Material.Round;
using MauiIcons.Material.Sharp;
using MauiIcons.Material.TwoTone;

namespace MauiIcons.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseFontAwesomeBrands()
            .UseFontAwesomeRegular()
            .UseFontAwesomeSolid()
			.UseMaterialOutlined()
			.UseMaterialRegular()
			.UseMaterialRound()
			.UseMaterialSharp()
			.UseMaterialTwoTone()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
