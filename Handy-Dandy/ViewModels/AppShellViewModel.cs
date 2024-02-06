using System;
using Handy_Dandy.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Handy_Dandy.ViewModels
{
	public class AppShellViewModel: BaseViewModel
	{
		public AsyncRelayCommand SignOutCommand { get; }
		public AppShellViewModel()
		{
			this.SignOutCommand = new AsyncRelayCommand(SignOut);
		}

		async Task SignOut()
		{
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}
	}
}

