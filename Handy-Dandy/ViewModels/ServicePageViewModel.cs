using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
	[QueryProperty("Category", "Category")]
	public partial class ServicePageViewModel: BaseViewModel
	{
		[ObservableProperty]
		CategoryModel category;

        public IAsyncRelayCommand TabServiceCommand { get; }
        private readonly IDatabaseService _dataService;
        public ServicePageViewModel(IDatabaseService dataService)
		{
            this._dataService = dataService;
            this.TabServiceCommand = new AsyncRelayCommand<ServiceModel>(
                async model => await OnTabService(model));
		}

        private async Task OnTabService(ServiceModel service)
        {
            if (service is null)
                return;

            await Task.Yield();
           // await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}

