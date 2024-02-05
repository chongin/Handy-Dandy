using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Views;

using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private bool isVisableError;

        public IAsyncRelayCommand LoginCommand { get; }
        public IAsyncRelayCommand SignUpCommand { get; }
        public IAsyncRelayCommand TextChangedCommand { get; }


        private readonly FireBaseService _fireBaseService;
		public LoginPageViewModel(FireBaseService fireBaseService)
		{
            this._fireBaseService = fireBaseService;

			this.LoginCommand = new AsyncRelayCommand(OnLogin);
			this.SignUpCommand = new AsyncRelayCommand(OnSignUp);
            this.TextChangedCommand = new AsyncRelayCommand(OnTextChanged);
        }

		private async Task OnLogin()
		{
            var user = await this._fireBaseService.QueryUserByEmail(Email);
            if (user == null)
            {
                ErrorMessage = "We can't seem to find your account.";
                IsVisableError = true;
                return;
            }
            if (user.Password != Password)
            {
                ErrorMessage = "Your password is not match your account.";
                IsVisableError = true;
                return;
            }

            else
            {
                Console.WriteLine("xxxxx");
                await Shell.Current.GoToAsync("//MainPage");
            }
        }

        private async Task OnSignUp()
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }

        private Task OnTextChanged()
        {
            ErrorMessage = string.Empty;
            IsVisableError = false;
            return Task.CompletedTask;
        }
    }
}

