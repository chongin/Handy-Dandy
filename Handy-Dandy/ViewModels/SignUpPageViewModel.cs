using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels
{
	public partial class SignUpPageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string phone;

        public IAsyncRelayCommand SignUpCommand { get; }
        private readonly IDatabaseService _dataService;

        public SignUpPageViewModel(IDatabaseService dataService)
		{
            this._dataService = dataService;
            SignUpCommand = new AsyncRelayCommand(SignUp);
        }


        public async Task SignUp()
        {
            var existUser = await this._dataService.QueryUserByEmail(Email);
            if (existUser != null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Oops! It seems that email is already taken.", "OK");
                return;
            }
            UserModel user = new UserModel();
            user.UserID = Guid.NewGuid().ToString();
            user.Email = Email;
            user.UserName = UserName;
            user.Phone = Phone;
            user.RoleID = UserRole.Client;
            user.Address = Address;
            user.Password = Password;
            user.City = "Sudbury";
            user.Avatar = "dotnet_bot";
 
            await this._dataService.InserUser(user);

            await Shell.Current.CurrentPage.DisplayAlert("Info", "Congratulations, your signup was successful!", "OK");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}


