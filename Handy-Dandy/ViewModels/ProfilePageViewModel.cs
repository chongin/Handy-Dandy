using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;

namespace Handy_Dandy.ViewModels
{
	public partial class ProfilePageViewModel : BaseViewModel
    {
		private IDatabaseService _databaseService;

        [ObservableProperty]
        private UserDto user;

        public ProfilePageViewModel(IDatabaseService databaseService)
		{
			this._databaseService = databaseService;
			InitData();

        }

		private async void InitData()
		{
			User = new UserDto(await this._databaseService.GetUserById("mockUserID"));
		}
	}
}

