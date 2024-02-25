using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels
{
	public partial class ProfilePageViewModel : BaseViewModel
    {
		private IDatabaseService _databaseService;

        [ObservableProperty]
        private UserDto user;

        public IAsyncRelayCommand AddressCommand { get; }
        public IAsyncRelayCommand LogoutCommand { get; }

        private INavigation _navigation;

        public ProfilePageViewModel(IDatabaseService databaseService, INavigation navigation)
		{
            _navigation = navigation;

            this._databaseService = databaseService;
			InitData();
            AddressCommand = new AsyncRelayCommand(OnClickAddress);
            LogoutCommand = new AsyncRelayCommand(OnLogout);
        }

		private async void InitData()
		{
			User = new UserDto(await this._databaseService.GetUserById("mockUserID"));
		}

        private async Task OnClickAddress()
        {
            //   await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            await Application.Current.MainPage.Navigation.PushAsync(new MapPage(new MapViewModel(_databaseService, _navigation)));
        }

        private async Task OnLogout()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}

