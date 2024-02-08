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
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddTransient<NotificationPage>();
        builder.Services.AddTransient<SettingPage>();
		builder.Services.AddTransient<ServicePage>();

		//services
        builder.Services.AddTransient< IDatabaseService, FireBaseService >(_ => new FireBaseService("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/"));

        //View Models
		builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddTransient<ServicePageViewModel>();

        return builder.Build();
	}
}

