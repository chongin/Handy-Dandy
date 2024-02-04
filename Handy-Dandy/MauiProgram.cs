using Microsoft.Extensions.Logging;
using Handy_Dandy.Views;
using Handy_Dandy.ViewModels;
using Handy_Dandy.Services;
using CommunityToolkit.Maui;

namespace Handy_Dandy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
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

		builder.Services.AddSingleton<FireBaseService>(_ => new FireBaseService("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/"));

        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<SignUpPageViewModel>();
        return builder.Build();
	}
}

