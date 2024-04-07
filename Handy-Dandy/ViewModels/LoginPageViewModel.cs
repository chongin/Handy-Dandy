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

        private readonly IDatabaseService _dataService;
        private readonly IDatabaseService1 _dataService1;

        public LoginPageViewModel(IDatabaseService dataService, IDatabaseService1 dataService1)
		{
            this._dataService = dataService;
            this._dataService1 = dataService1;
            this.LoginCommand = new AsyncRelayCommand(OnLogin);
			this.SignUpCommand = new AsyncRelayCommand(OnSignUp);
            this.TextChangedCommand = new AsyncRelayCommand(OnTextChanged);
        }

		private async Task OnLogin()
		{
            Email = "chongin@gmail.com";
            Password = "A12345!";
            var user = await this._dataService.QueryUserByEmail(Email);
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

            _dataService1.SetCurrentUser(user);
            await _dataService1.InitData();
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async Task OnSignUp()
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }


        private Task OnTextChanged()
        {
            ErrorMessage = string.Empty;
            IsVisableError = false;
            return Task.CompletedTask;
        }
    }
}

