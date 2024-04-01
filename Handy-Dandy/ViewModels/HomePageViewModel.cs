using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;

namespace Handy_Dandy.ViewModels
{
    [QueryProperty("User", "user")]
    public partial class HomePageViewModel: BaseViewModel
    {

        public List<PromotionDto> Promotions { get; set; }

        public List<CategoryDto> Categories { get; set; }



        [ObservableProperty]
        private PromotionDto selectedItem;

        public IAsyncRelayCommand CarouselPositionChangedCommand { get; }

        public IAsyncRelayCommand SelectionChangedCommand { get; }
        public IAsyncRelayCommand TabCategoryCommand { get; }
        private IDatabaseService1 _databaseService1;
        private INavigation _navigation;
        public HomePageViewModel(IDatabaseService1 databaseService1, INavigation navigation)
		{
            _navigation = navigation;
            _databaseService1 = databaseService1;
            CarouselPositionChangedCommand = new AsyncRelayCommand<int>(async (currentPosition) => await OnCarouselPositionChanged(currentPosition));
        

            SelectionChangedCommand = new AsyncRelayCommand<PromotionDto>(
                async (currentItem) => await OnSelectionChanged(currentItem));

            TabCategoryCommand = new AsyncRelayCommand<CategoryDto>(
                async (model) => await OnTabCategory(model));

            InitData();
        }

		public async void InitData()
		{
            this.Promotions = ConvertDto.ConvertToPromotionDtoList(_databaseService1.GetPromotions());
            this.Categories = ConvertDto.ConvertToCategoryDtoDtoList(_databaseService1.GetCategories());
        }

        private async Task OnSelectionChanged(PromotionDto currentItem)
        {
            if (currentItem != null)
            {
                string introDescription = currentItem.Description;
                string introImage = currentItem.ImageName;
            }
            await Task.Yield();
        }

        private async Task OnTabCategory(CategoryDto category)
        {
            if (category is null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new ServicePage(new ServicePageViewModel(_databaseService1, category, _navigation)));
        }

        private async Task OnCarouselPositionChanged(int currentPosition)
        {
            // UpdateButtonText();
            Console.WriteLine($"current position: {currentPosition}");
            await Task.Yield();
        }
    }
}

