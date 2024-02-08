using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Handy_Dandy.Models;
using Handy_Dandy.Views;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
	public partial class HomePageViewModel: BaseViewModel
    {

        public List<PromotionModel> Promotions { get; set; }

        public List<CategoryModel> Categories { get; set; }



        [ObservableProperty]
        private PromotionModel selectedItem;

        public IAsyncRelayCommand SelectionChangedCommand { get; }
        public IAsyncRelayCommand TabCategoryCommand { get; }
        private IDatabaseService _databaseService;
        public HomePageViewModel(IDatabaseService databaseService)
		{
            this._databaseService = databaseService;
            SelectionChangedCommand = new AsyncRelayCommand<PromotionModel>(
                async (currentItem) => await OnSelectionChanged(currentItem));

            TabCategoryCommand = new AsyncRelayCommand<CategoryModel>(
                async (model) => await OnTabCategory(model));

            InitData();
        }

		public async void InitData()
		{
            this.Promotions = await this._databaseService.GetPromotions();
            this.Categories = await this._databaseService.GetCategories();
        }

        private async Task OnSelectionChanged(PromotionModel currentItem)
        {
            if (currentItem != null)
            {
                string introDescription = currentItem.Description;
                string introImage = currentItem.ImageName;
            }
            await Task.Yield();
        }

        private async Task OnTabCategory(CategoryModel category)
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

