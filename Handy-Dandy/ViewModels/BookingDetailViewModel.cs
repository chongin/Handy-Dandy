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
        CategoryDto category;

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

		private IDatabaseService _databaseService { get; set; }
		public BookingDetailViewModel(IDatabaseService databaseService)
		{
            BookingDetailDisplay = new BookingDetailDto();
			TabTimeCommand = new AsyncRelayCommand<TimeDisplayModel>(
				async (arg) => await OnTabTime(arg));

            TabDateCommand = new AsyncRelayCommand<DateDisplayModel>(
                async (arg) => await OnTabDate(arg));

            TabWorkerCommand = new AsyncRelayCommand<WorkerDto>(
                async (arg) => await OnTabWorker(arg));

			BackCommand = new AsyncRelayCommand(OnBackPressed);
            this._databaseService = databaseService;


			InitModel();
            InitDates();
			InitTimes();
        }

		private async void InitModel()
		{
            BookingDetailDisplay.ServiceDto = new ServiceDto(await this._databaseService.GetServiceByID("MockServiceID"));
			BookingDetailDisplay.WorkerDtos = ConvertDto.ConvertToWorkerDtoList(await this._databaseService.GetWorkersByServiceID(BookingDetailDisplay.ServiceDto.ServiceId));
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
            await Shell.Current.GoToAsync($"{nameof(ServicePage)}", true,
                new Dictionary<string, object>{
                    { "Category", Category }
                });
        }

        private async Task OnConfirmed()
        {

        }
    }
}

