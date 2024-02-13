using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;
using static Microsoft.Maui.LifecycleEvents.AndroidLifecycle;

namespace Handy_Dandy.ViewModels
{
	[QueryProperty("Category", "Category")]
	public partial class ServicePageViewModel: BaseViewModel
	{
		[ObservableProperty]
		CategoryDto category;

        private ServiceDto selectServiceDto = null; 
        public IAsyncRelayCommand TabServiceCommand { get; }
        public IAsyncRelayCommand TabBookingDetailCommand { get; }
        public IAsyncRelayCommand BackCommand { get; }

        private readonly IDatabaseService _dataService;

        public ServicePageViewModel(IDatabaseService dataService)
		{
            this._dataService = dataService;
            this.TabServiceCommand = new AsyncRelayCommand<ServiceDto>(
                async model => await OnTabService(model));

            BackCommand = new AsyncRelayCommand(OnBackPressed);
            this.TabBookingDetailCommand = new AsyncRelayCommand<ServiceDto>(
                async model => await OnClcikGoToBookingDetail(model));
		}

        private async Task OnTabService(ServiceDto service)
        {
            if (service is null)
                return;

            selectServiceDto = service;

            await Shell.Current.GoToAsync($"{nameof(BookingDetailPage)}", true,
               new Dictionary<string, Object>{
                    { "Category",  Category }
               });
        }

        private async Task OnClcikGoToBookingDetail(ServiceDto service)
        {
            selectServiceDto = service;
            if (selectServiceDto is null) {
                return;
            }

           // await Shell.Current.Navigation.PushAsync(new ServicePage(this));
            await Shell.Current.GoToAsync($"{nameof(BookingDetailPage)}", true,
                new Dictionary<string, Object>{
                    { "Category",  Category }
                });
        }

        private async Task OnBackPressed()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}", true);
        }
    }
}

