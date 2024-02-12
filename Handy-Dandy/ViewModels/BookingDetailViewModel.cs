using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels.DisplayModels;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
	public partial class BookingDetailViewModel: BaseViewModel
	{

		[ObservableProperty]
		private BookingDetailDisplayModel bookingDetailDisplay;

		[ObservableProperty]
		private List<DateDisplayModel> next7Dates = new List<DateDisplayModel>();

		[ObservableProperty]
		private List<TimeDisplayModel> startWorkTimes = new List<TimeDisplayModel>();

		public IAsyncRelayCommand TabTimeCommand { get; }
        public IAsyncRelayCommand TabDateCommand { get; }
		public IAsyncRelayCommand TabWorkerCommand { get; set; }
        private int currentSelectTimeIndex = 0;
		private int currentSelectDateIndex = 0;
		private int currentSelectWorkerIndex = 0;

		private IDatabaseService _databaseService { get; set; }
		public BookingDetailViewModel(IDatabaseService databaseService)
		{
			BookingDetailDisplay = new BookingDetailDisplayModel();
			TabTimeCommand = new AsyncRelayCommand<TimeDisplayModel>(
				async (arg) => await OnTabTime(arg));

            TabDateCommand = new AsyncRelayCommand<DateDisplayModel>(
                async (arg) => await OnTabDate(arg));

            TabWorkerCommand = new AsyncRelayCommand<WorkerDto>(
                async (arg) => await OnTabWorker(arg));

            this._databaseService = databaseService;


			InitModel();
            InitDates();
			InitTimes();
        }

		private async void InitModel()
		{
            BookingDetailDisplay.ServiceDto = new ServiceDto(await this._databaseService.GetServiceByID("MockServiceID"));
			BookingDetailDisplay.WorkerDtos = ConvertDto.ConvertToWorkerDtoList(await this._databaseService.GetWorkersByServiceID(BookingDetailDisplay.ServiceDto.ServiceID));
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
    }
}

