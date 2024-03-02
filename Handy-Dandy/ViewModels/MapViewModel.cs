using System;
using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Views;
using Newtonsoft.Json;
using System.Net;

namespace Handy_Dandy.ViewModels
{
	public partial class MapViewModel : BaseViewModel
    {
        private IDatabaseService _databaseService;
        public ObservableCollection<CountryModel> CountryList { get; set; }
        public ObservableCollection<ProvinceModel> ProvinceData { get; set; }
        //public IAsyncRelayCommand BackCommand { get; }
        private INavigation _navigation;
        public MapViewModel(IDatabaseService databaseService, INavigation navigation)
		{
			this._databaseService = databaseService;
            this._navigation = navigation;
            // BackCommand = new AsyncRelayCommand(OnBackPressed);
            GenerateSource();
            PopulateProvinceData();
        }

        private void PopulateProvinceData()
        {
            // Assuming ProvinceModel has properties like ProvinceName, ProvinceCode, etc.
            ProvinceData = new ObservableCollection<ProvinceModel>
            {
                new ProvinceModel { ProvinceName = "Ontario", ProvinceCode = "ON" },
                new ProvinceModel { ProvinceName = "Quebec", ProvinceCode = "QC" },
                // Add more provinces as needed
            };
        }

        public void GenerateSource()
        {
            CountryList = new ObservableCollection<CountryModel>();
            CountryList.Add(new CountryModel("Argentina"));
            CountryList.Add(new CountryModel("India"));
            CountryList.Add(new CountryModel("United States"));

        }
    }
}

