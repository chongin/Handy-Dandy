using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Handy_Dandy.Models;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels.Login
{
    public partial class LoginPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public IAsyncRelayCommand LoginCommand { get; }
		public IAsyncRelayCommand SignUpCommand { get; }
		public LoginPageViewModel()
		{
			this.LoginCommand = new AsyncRelayCommand(Login);
			SignUpCommand = new AsyncRelayCommand(SignUp);
		}

		private async Task Login()
		{
            //App.CurrentUser.Email = Email;
            //App.CurrentUser.Password = Password;
            await Shell.Current.GoToAsync("//MainPage");
        }

        public async Task SignUp()
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }
    }
}

