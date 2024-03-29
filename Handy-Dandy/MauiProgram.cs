﻿using Microsoft.Extensions.Logging;
using Handy_Dandy.Views;
using Handy_Dandy.ViewModels;
using Handy_Dandy.Services;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;

namespace Handy_Dandy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiMaps()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<INavigation>(provider => Application.Current.MainPage.Navigation);
        //Views
        builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<NotificationPage>();
        builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<ServicePage>();
        builder.Services.AddTransient<BookingDetailPage>();
        builder.Services.AddTransient<MapPage>();

        //services
        builder.Services.AddSingleton< IDatabaseService1, FireBaseService >(_ => new FireBaseService("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/"));
        builder.Services.AddSingleton<IDatabaseService, FireBaseServiceMock>(_ => new FireBaseServiceMock("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/"));

        //View Models
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<ServicePageViewModel>();
        builder.Services.AddTransient<BookingViewModel>();
        builder.Services.AddTransient<BookingDetailViewModel>();
        builder.Services.AddTransient<ProfilePageViewModel>();
        builder.Services.AddTransient<MapViewModel>();

        // add navigation service
        builder.Services.AddSingleton<INavigation>(provider => Application.Current.MainPage.Navigation);
        return builder.Build();
	}
}

