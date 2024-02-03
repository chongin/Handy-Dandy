using Microsoft.Extensions.Logging;
using Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

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

        builder.Services.AddSingleton<MainPage>();

        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<SignUpPageViewModel>();
        return builder.Build();
	}
}

