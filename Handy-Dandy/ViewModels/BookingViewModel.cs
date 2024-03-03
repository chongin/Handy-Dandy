using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Handy_Dandy.Models;
using Handy_Dandy.ViewModels;
using Handy_Dandy.Services;
using Handy_Dandy.ViewModels.Dtos;

namespace Handy_Dandy.ViewModels
{


    public partial class BookingViewModel : BaseViewModel
    {
        private IDatabaseService _databaseService;


        public List<BookingDisplayDto> ActiveBookingModels { get; set; }
        public List<BookingDisplayDto> SuccessBookingModels { get; set; }
        public List<BookingDisplayDto> CancelBookingModels { get; set; }

        private List<BookingDisplayDto> _currentBookingModels;
        public List<BookingDisplayDto> CurrentBookingModels
        {
            get => _currentBookingModels;
            set => SetProperty(ref _currentBookingModels, value);
        }

        public int CurrentPage { get; set; }

        public IAsyncRelayCommand ActiveCommand { get; }
        public IAsyncRelayCommand SuccessCommand { get; }
        public IAsyncRelayCommand CancelledCommand { get; }

        [ObservableProperty]
        private Color activeButtonColor;
        [ObservableProperty]
        private Color successButtonColor;
        [ObservableProperty]
        private Color cancelledButtonColor;

        public BookingViewModel(IDatabaseService databaseService)
		{
            ActiveCommand = new AsyncRelayCommand(OnClickActive);
            SuccessCommand = new AsyncRelayCommand(OnClickSuccess);
            CancelledCommand = new AsyncRelayCommand(OnClickCancelled);

            this._databaseService = databaseService;
            CurrentBookingModels = new List<BookingDisplayDto>();
            CurrentPage = 1;
            InitData();
		}

		private async void InitData()
		{
			ActiveBookingModels = await GetBookingModel("Active");
            CurrentBookingModels = ActiveBookingModels;
            updateButtonColor();
        }

		private async Task<List<BookingDisplayDto>> GetBookingModel(string state)
		{
			List<BookingDisplayDto> Models = new List<BookingDisplayDto>();
            var bookingModels = await this._databaseService.GetBookingsByState(state);
            foreach (var bookingModel in bookingModels)
            {
                var workerModel = await this._databaseService.GetWorkerByID(bookingModel.WorkerId);
                var serviceModel = await this._databaseService.GetServiceByID(bookingModel.ServiceId);

                BookingDisplayDto model = new BookingDisplayDto();
                model.BookingDto = new BookingDto(bookingModel);
                model.WorkerDto = new WorkerDto(workerModel);
                model.ServiceDto = new ServiceDto(serviceModel);
                Models.Add(model);
            }
			return Models;
        }

        public async Task OnClickActive()
        {
            CurrentPage = 1;
            updateButtonColor();
            if (ActiveBookingModels is null || ActiveBookingModels.Count == 0)
            {
                ActiveBookingModels = await GetBookingModel("Active");
            }
            CurrentBookingModels = ActiveBookingModels;
        }

        public async Task OnClickSuccess()
        {
            CurrentPage = 2;
            updateButtonColor();
            if (SuccessBookingModels is null || SuccessBookingModels.Count == 0)
            {
                SuccessBookingModels = await GetBookingModel("Success");
            }
            CurrentBookingModels = SuccessBookingModels;
        }

        public async Task OnClickCancelled()
        {
            CurrentPage = 3;
            updateButtonColor();
            if (CancelBookingModels is null || CancelBookingModels.Count == 0)
            {
                CancelBookingModels = await GetBookingModel("Cancelled");
            }
            CurrentBookingModels = CancelBookingModels;
        }

        private void updateButtonColor()
        {
            ActiveButtonColor = Color.FromRgb(135, 206, 250);
            SuccessButtonColor = Color.FromRgb(135, 206, 250);
            CancelledButtonColor = Color.FromRgb(135, 206, 250);
            if (CurrentPage == 1) {
                ActiveButtonColor = Color.FromRgb(120, 195, 230);
            }
            else if (CurrentPage == 2) {
                SuccessButtonColor = Color.FromRgb(120, 195, 230);
            }
            else {
                CancelledButtonColor = Color.FromRgb(120, 195, 230);
            }
        }
    }
}

