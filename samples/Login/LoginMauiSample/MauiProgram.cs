using Microsoft.Extensions.Logging;
using Plugin.FacebookKit.Login;

namespace LoginMauiSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseFacebookLoginControls();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
