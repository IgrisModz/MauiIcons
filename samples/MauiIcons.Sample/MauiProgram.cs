using MauiIcons.FontAwesome.Regular;
using MauiIcons.FontAwesome.Brands;
using MauiIcons.FontAwesome.Solid;

namespace MauiIcons.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseFontAwesomeRegular()
			.UseFontAwesomeBrands()
            .UseFontAwesomeSolid()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
