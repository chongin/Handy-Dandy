﻿using Handy_Dandy.Views;
using Handy_Dandy.ViewModels;

namespace Handy_Dandy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();

		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
        Routing.RegisterRoute(nameof(NotificationPage), typeof(NotificationPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(BookingDetailPage), typeof(BookingDetailPage));

        Routing.RegisterRoute(nameof(ServicePage), typeof(ServicePage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    }
}

