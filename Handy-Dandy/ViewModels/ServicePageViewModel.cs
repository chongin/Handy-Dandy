using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;

namespace Handy_Dandy.ViewModels
{
	public partial class ServicePageViewModel: BaseViewModel
	{
		[ObservableProperty]
		CategoryDto category;

        private ServiceDto selectServiceDto = null; 
        public IAsyncRelayCommand TabServiceCommand { get; }
        public IAsyncRelayCommand TabBookingDetailCommand { get; }
        public IAsyncRelayCommand BackCommand { get; }

        private readonly IDatabaseService1 _dataService1;
        private INavigation _navigation;
        public ServicePageViewModel(IDatabaseService1 dataService1, CategoryDto category, INavigation navigation)
		{
            _navigation = navigation;
            Category = category;
            this._dataService1 = dataService1;
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

            await Application.Current.MainPage.Navigation.PushAsync(new BookingDetailPage(new BookingDetailViewModel(_dataService1, service, _navigation)));

            //await Shell.Current.GoToAsync($"{nameof(BookingDetailPage)}", true,
            //   new Dictionary<string, Object>{
            //        { "Category",  Category }
            //   });
        }

        private async Task OnClcikGoToBookingDetail(ServiceDto service)
        {
            selectServiceDto = service;
            if (selectServiceDto is null) {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new BookingDetailPage(new BookingDetailViewModel(_dataService1, service, _navigation)));

            //await Shell.Current.GoToAsync($"{nameof(BookingDetailPage)}", true,
            //    new Dictionary<string, Object>{
            //        { "Category",  Category }
            //    });
        }

        private async Task OnBackPressed()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HomePage(new HomePageViewModel(_dataService1, _navigation)));
        }
    }
}

