using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

        public SignUpPageViewModel()
		{
            SignUpCommand = new AsyncRelayCommand(SignUp);
        }

        public async Task SignUp()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}

