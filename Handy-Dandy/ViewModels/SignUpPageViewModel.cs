using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Handy_Dandy.Models;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
	public partial class SignUpPageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string password;


        public IAsyncRelayCommand SignUpCommand { get; }
        private readonly FireBaseService _fireBaseService;

        public SignUpPageViewModel(FireBaseService fireBaseService)
		{
            this._fireBaseService = fireBaseService;
            SignUpCommand = new AsyncRelayCommand(SignUp);
        }

        public async Task SignUp()
        {
            User user = new User();
            user.Email = Email;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Phone = Phone;
            user.RoleID = UserRole.Client;
            user.Address = Address;
            await this._fireBaseService.InserUser(user);
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}

