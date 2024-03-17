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
        private IDatabaseService _databaseService;
        private IDatabaseService1 _databaseService1;
        public HomePageViewModel(IDatabaseService databaseService, IDatabaseService1 databaseService1)
		{
            this._databaseService = databaseService;
            this._databaseService1 = databaseService1;
            CarouselPositionChangedCommand = new AsyncRelayCommand<int>(async (currentPosition) => await OnCarouselPositionChanged(currentPosition));
        

            SelectionChangedCommand = new AsyncRelayCommand<PromotionDto>(
                async (currentItem) => await OnSelectionChanged(currentItem));

            TabCategoryCommand = new AsyncRelayCommand<CategoryDto>(
                async (model) => await OnTabCategory(model));

            InitData();
        }

		public async void InitData()
		{
            this.Promotions = ConvertDto.ConvertToPromotionDtoList(await this._databaseService.GetPromotions());
            this.Categories = ConvertDto.ConvertToCategoryDtoDtoList(this._databaseService1.GetCategories());
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

            await Shell.Current.GoToAsync($"{nameof(ServicePage)}", true,
                new Dictionary<string, object>
                {
                    { "Category", category }
                });
        }

        private async Task OnCarouselPositionChanged(int currentPosition)
        {
            // UpdateButtonText();
            Console.WriteLine($"current position: {currentPosition}");
            await Task.Yield();
        }
    }
}

