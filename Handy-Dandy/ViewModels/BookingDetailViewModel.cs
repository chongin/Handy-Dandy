using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Services;
using Handy_Dandy.Views;

namespace Handy_Dandy.ViewModels
{
    [QueryProperty("Category", "Category")]
    public partial class BookingDetailViewModel: BaseViewModel
	{

        [ObservableProperty]
        ServiceDto service;

        [ObservableProperty]
		private BookingDetailDto bookingDetailDisplay;

		[ObservableProperty]
		private List<DateDisplayModel> next7Dates = new List<DateDisplayModel>();

		[ObservableProperty]
		private List<TimeDisplayModel> startWorkTimes = new List<TimeDisplayModel>();

		public IAsyncRelayCommand TabTimeCommand { get; }
        public IAsyncRelayCommand TabDateCommand { get; }
		public IAsyncRelayCommand TabWorkerCommand { get; }
		public IAsyncRelayCommand BackCommand { get; }

        private int currentSelectTimeIndex = 0;
		private int currentSelectDateIndex = 0;
		private int currentSelectWorkerIndex = 0;

		private IDatabaseService1 _databaseService1 { get; set; }
        private INavigation _navigation;
        public BookingDetailViewModel(IDatabaseService1 databaseService1, ServiceDto service, INavigation navigation)
		{
            _navigation = navigation;
            Service = service;
            BookingDetailDisplay = new BookingDetailDto();
			TabTimeCommand = new AsyncRelayCommand<TimeDisplayModel>(
				async (arg) => await OnTabTime(arg));

            TabDateCommand = new AsyncRelayCommand<DateDisplayModel>(
                async (arg) => await OnTabDate(arg));

            TabWorkerCommand = new AsyncRelayCommand<WorkerDto>(
                async (arg) => await OnTabWorker(arg));

			BackCommand = new AsyncRelayCommand(OnBackPressed);
            this._databaseService1 = databaseService1;


			InitModel();
            InitDates();
			InitTimes();
        }

		private async void InitModel()
		{
            BookingDetailDisplay.ServiceDto = Service;
            BookingDetailDisplay.WorkerDtos = ConvertDto.ConvertToWorkerDtoList(this._databaseService1.GetWorkersByServiceId(Service.ServiceId));
        }
		private void InitDates()
		{
			DateTime currentDate = DateTime.Today;
            Next7Dates.Add(new DateDisplayModel(currentDate));

			for (int i = 1; i < 10; i++)
			{
				DateTime nextDate = currentDate.AddDays(i);
                Next7Dates.Add(new DateDisplayModel(nextDate));
            }
		}

		private void InitTimes()
		{
			for (int i = 0; i <= 8; ++i)
			{
				int hour = 8 + i;
                StartWorkTimes.Add(new TimeDisplayModel(hour));
            }
		}

		private async Task OnTabTime(TimeDisplayModel timeModel)
		{
            var preTime = StartWorkTimes[currentSelectTimeIndex];
            preTime.CurrentColor = Color.FromArgb("#00000000");

            int currentIndex = StartWorkTimes.IndexOf(timeModel);
			timeModel.CurrentColor = Color.FromRgb(35, 206, 250);

            currentSelectTimeIndex = currentIndex;
        }

        private async Task OnTabDate(DateDisplayModel dateModel)
        {
			var preDate = Next7Dates[currentSelectDateIndex];
            preDate.CurrentColor = Color.FromArgb("#00000000");

			int currentIndex = Next7Dates.IndexOf(dateModel);
            dateModel.CurrentColor = Color.FromRgb(35, 206, 250);

			currentSelectDateIndex = currentIndex;
		}

        private async Task OnTabWorker(WorkerDto workerDto)
        {
            var preWorker = BookingDetailDisplay.WorkerDtos[currentSelectWorkerIndex];
            preWorker.CurrentColor = Color.FromArgb("#00000000");

            int currentIndex = BookingDetailDisplay.WorkerDtos.IndexOf(workerDto);
            workerDto.CurrentColor = Color.FromRgb(35, 206, 250);

            currentSelectWorkerIndex = currentIndex;
        }

        private async Task OnBackPressed()
        {
            var categoryModel = _databaseService1.GetCategoryById(Service.CategoryId);

            await Application.Current.MainPage.Navigation.PushAsync(new ServicePage(new ServicePageViewModel(_databaseService1, new CategoryDto(categoryModel), _navigation)));

            //await Shell.Current.GoToAsync($"{nameof(ServicePage)}", true,
            //    new Dictionary<string, object>{
            //        { "Category", Category }
            //    });
        }

        private async Task OnConfirmed()
        {

        }
    }
}

