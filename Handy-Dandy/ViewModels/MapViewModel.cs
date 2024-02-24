using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels
{
	public partial class MapViewModel : BaseViewModel
    {
        private IDatabaseService _databaseService;
        public ObservableCollection<CountryModel> CountryList { get; set; }
        public IAsyncRelayCommand BackCommand { get; }

        public MapViewModel(IDatabaseService databaseService)
		{
			this._databaseService = databaseService;
            BackCommand = new AsyncRelayCommand(OnBackPressed);
        }

        private async Task OnBackPressed()
        {
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}", true);
        }
    }
}

