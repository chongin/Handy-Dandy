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
		private BookingDetailDisplayModel bookingDetailDisplayModel;

		[ObservableProperty]
		private List<DateDisplayModel> next7Dates = new List<DateDisplayModel>();

		[ObservableProperty]
		private List<TimeDisplayModel> startWorkTimes = new List<TimeDisplayModel>();

		public IAsyncRelayCommand TabTimeCommand { get; }

		private int currentSelectTimeIndex = 0;

		private IDatabaseService _databaseService { get; set; }
		public BookingDetailViewModel(IDatabaseService databaseService)
		{
			TabTimeCommand = new AsyncRelayCommand<TimeDisplayModel>(
				async (arg) => await OnTabTime(arg));

            this._databaseService = databaseService;
			InitDates();
			InitTimes();
        }

		private void InitDates()
		{
			DateTime currentDate = DateTime.Today;
            Next7Dates.Add(new DateDisplayModel(currentDate));

			for (int i = 1; i < 7; i++)
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
            preTime.CurrentColor = Color.FromRgb(135, 206, 250);

            int currentIndex = StartWorkTimes.IndexOf(timeModel);
			timeModel.CurrentColor = Color.FromRgb(0, 0, 230);

			currentSelectTimeIndex = currentIndex;
        }
	}
}

