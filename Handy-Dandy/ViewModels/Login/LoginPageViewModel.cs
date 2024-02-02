using System;
using CommunityToolkit.Mvvm.ComponentModel;
namespace Handy_Dandy.ViewModels.Login
{
    public partial class LoginPageViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _email;

		[ObservableProperty]
		private string _password;

		public LoginPageViewModel()
		{
		}
	}
}

