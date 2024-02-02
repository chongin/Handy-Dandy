using Microsoft.Extensions.Logging;
using Handy_Dandy.Views.Login;
using Handy_Dandy.ViewModels.Login;

namespace Handy_Dandy;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		//Views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<SignUpPage>();

		//View Models
		builder.Services.AddSingleton<LoginPageViewModel>();

		return builder.Build();
	}
}

