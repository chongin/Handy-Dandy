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
	public partial class HomePageViewModel: BaseViewModel
    {

        public List<PromotionDto> Promotions { get; set; }

        public List<CategoryDto> Categories { get; set; }



        [ObservableProperty]
        private PromotionDto selectedItem;

        public IAsyncRelayCommand SelectionChangedCommand { get; }
        public IAsyncRelayCommand TabCategoryCommand { get; }
        private IDatabaseService _databaseService;
        public HomePageViewModel(IDatabaseService databaseService)
		{
            this._databaseService = databaseService;
            SelectionChangedCommand = new AsyncRelayCommand<PromotionDto>(
                async (currentItem) => await OnSelectionChanged(currentItem));

            TabCategoryCommand = new AsyncRelayCommand<CategoryDto>(
                async (model) => await OnTabCategory(model));

            InitData();
        }

		public async void InitData()
		{
            this.Promotions = ConvertDto.ConvertToPromotionDtoList(await this._databaseService.GetPromotions());
            this.Categories = ConvertDto.ConvertToCategoryDtoDtoList(await this._databaseService.GetCategories());
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
    }
}

