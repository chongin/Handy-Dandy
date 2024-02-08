using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Handy_Dandy.Models;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels
{
	public partial class HomePageViewModel: BaseViewModel
    {

        public ObservableCollection<IntroduceModel> IntroServices { get; set; }

        public ObservableCollection<CategoryModel> Categories { get; set; }



        [ObservableProperty]
        private IntroduceModel selectedItem;

        //private IntroduceModel _selectedItem;
        //public IntroduceModel SelectedItem
        //{
        //    get => _selectedItem;
        //    set => SetProperty(ref _selectedItem, value);
        //}
        public IAsyncRelayCommand SelectionChangedCommand { get; }
        public IAsyncRelayCommand TabCategoryCommand { get; }
        public HomePageViewModel()
		{
            SelectionChangedCommand = new AsyncRelayCommand<IntroduceModel>(
                async (currentItem) => await OnSelectionChanged(currentItem));

            TabCategoryCommand = new AsyncRelayCommand<CategoryModel>(
                async (model) => await OnTabCategory(model));

            this.IntroServices = new ObservableCollection<IntroduceModel>();
            this.Categories = new ObservableCollection<CategoryModel>();

            InitData();
        }

		public void InitData()
		{
            InitIntroServices();
            InitCategories();
        }

        private async Task OnSelectionChanged(IntroduceModel currentItem)
        {
            if (currentItem != null)
            {
                string introDescription = currentItem.IntroDescription;
                string introImage = currentItem.IntroImage;
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
            for (int i = 0; i < 9; ++i)
            {
                Categories.Add(CreateCategoryModel(i));
            }
        }

        private CategoryModel CreateCategoryModel(int index)
        {
            List<string> categoryImageNames = new List<string> { "category_cleaning", "category_repairing", "category_beauty" };
            List<string> categoryName = new List<string> { "Cleaning", "Repairing", "Beauty" };
            Random random = new Random();
            int randomNameIndex = random.Next(categoryImageNames.Count);
            CategoryModel category = new CategoryModel
            {
                CategoryID = $"C{index}_{randomNameIndex}",
                Name = $"{categoryName[randomNameIndex]}{index}",
                CategoryImage = $"{categoryImageNames[randomNameIndex]}",
                Services = new List<ServiceModel>()
            };

            List<string> serviceImageNames = new List<string> { "sercie_clean_floor", "service_clean_ac", "service_clean_wall",
                "service_laundry", "service_maintain_light", "service_repair_appliance"};

            List<string> serviceNames = new List<string> { "Clean Floor", "Clean AC", "Clean Wall",
                "Laundry", "Maintain Light", "Repair Appliance"};

            int numberOfServices = random.Next(3, 11);

            for (int j = 0; j < numberOfServices; j++)
            {
                int randomIndex = random.Next(serviceNames.Count);
                ServiceModel service = new ServiceModel
                {
                    ServiceID = $"{category.CategoryID}_S{j}",
                    CategoryID = category.CategoryID,
                    Name = $"{serviceNames[randomIndex]}",
                    Description = $"Description of Service {serviceNames[randomIndex]}",
                    ServiceCharge = random.Next(20, 100),
                    Score = 3f + (float)random.NextDouble() * 2f,
                    CompletedCount = random.Next(60, 199),
                    ImageName = $"{serviceImageNames[randomIndex]}"
                };
                category.Services.Add(service);
            }


            return category;
        }
    }
}

