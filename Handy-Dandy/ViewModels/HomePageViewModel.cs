using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Handy_Dandy.Models;
using System.Windows.Input;

namespace Handy_Dandy.ViewModels
{
	public partial class HomePageViewModel: BaseViewModel
    {

        public ObservableCollection<IntroduceModel> IntroServices { get; set; }

        public ObservableCollection<CategoryModel> Categories { get; set; }

        private string _buttonText = "Next";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        [ObservableProperty]
        private int position;

        private int CurrentPosition = 0;

        public IAsyncRelayCommand CarouselPositionChangedCommand { get; }

        public HomePageViewModel()
		{
            CarouselPositionChangedCommand = new AsyncRelayCommand<int>(
                async (currentPosition) => await OnCarouselPositionChanged(currentPosition)
            );
            this.IntroServices = new ObservableCollection<IntroduceModel>();
            this.Categories = new ObservableCollection<CategoryModel>();

            InitData();
        }

		public void InitData()
		{
            InitIntroServices();
            InitCategories();
        }

        private async Task OnCarouselPositionChanged(int currentPosition)
        {
            Console.WriteLine($"current position: {currentPosition}");
            await Task.Yield();
        }

        private void InitIntroServices()
        {
            IntroServices.Add(new IntroduceModel
            {
                IntroTitle = "Cleaning",
                IntroDescription = "Best Cleaning",
                IntroImage = "cleaning"
            });

            IntroServices.Add(new IntroduceModel
            {
                IntroTitle = "Repairing",
                IntroDescription = "Best Repairing",
                IntroImage = "repairing"
            });

            IntroServices.Add(new IntroduceModel
            {
                IntroTitle = "Painting",
                IntroDescription = "Best Painting",
                IntroImage = "painting"
            });
        }

        private void InitCategories()
        {
            Categories.Add(new CategoryModel
            {
                CategoryID = "c1",
                Name = "Repairing",
                CategoryImage = "category_repairing",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c2",
                Name = "Cleaning",
                CategoryImage = "category_cleaning",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c3",
                Name = "Beauty",
                CategoryImage = "category_beauty",
            });
            Categories.Add(new CategoryModel
            {
                CategoryID = "c11",
                Name = "Repairing1",
                CategoryImage = "category_repairing",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c21",
                Name = "Cleaning1",
                CategoryImage = "category_cleaning",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c31",
                Name = "Beauty1",
                CategoryImage = "category_beauty",
            });
            Categories.Add(new CategoryModel
            {
                CategoryID = "c12",
                Name = "Repairing2",
                CategoryImage = "category_repairing",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c22",
                Name = "Cleaning2",
                CategoryImage = "category_cleaning",
            });

            Categories.Add(new CategoryModel
            {
                CategoryID = "c32",
                Name = "Beauty",
                CategoryImage = "category_beauty",
            });
        }
    }
}

