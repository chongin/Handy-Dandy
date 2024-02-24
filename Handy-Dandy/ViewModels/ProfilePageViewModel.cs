using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Views;
using static Microsoft.Maui.LifecycleEvents.AndroidLifecycle;

namespace Handy_Dandy.ViewModels
{
	public partial class ProfilePageViewModel : BaseViewModel
    {
		private IDatabaseService _databaseService;

        [ObservableProperty]
        private UserDto user;

        public IAsyncRelayCommand AddressCommand { get; }

        public ProfilePageViewModel(IDatabaseService databaseService)
		{
			this._databaseService = databaseService;
			InitData();
            AddressCommand = new AsyncRelayCommand(OnClickAdress);
        }

		private async void InitData()
		{
			User = new UserDto(await this._databaseService.GetUserById("mockUserID"));
		}

        private async Task OnClickAdress()
        {
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }
    }
}

