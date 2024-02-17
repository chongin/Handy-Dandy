﻿using Microsoft.Extensions.Logging;
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
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<NotificationPage>();
        builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<ServicePage>();
        builder.Services.AddTransient<BookingDetailPage>();

        //services
        builder.Services.AddTransient< IDatabaseService, FireBaseService >(_ => new FireBaseService("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/"));

        //View Models
		builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<ServicePageViewModel>();
        builder.Services.AddTransient<BookingViewModel>();
        builder.Services.AddTransient<BookingDetailViewModel>();
        builder.Services.AddTransient<ProfilePageViewModel>();

        return builder.Build();
	}
}

