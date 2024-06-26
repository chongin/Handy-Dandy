﻿using System;
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
        private IDatabaseService1 _databaseService;
        private INavigation _navigation;

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

        public IAsyncRelayCommand CompleteCommand { get; }
        public IAsyncRelayCommand CancelCommand { get; }

        [ObservableProperty]
        private Color activeButtonColor;
        [ObservableProperty]
        private Color successButtonColor;
        [ObservableProperty]
        private Color cancelledButtonColor;

        public BookingViewModel(IDatabaseService1 databaseService, INavigation navigation)
		{
            _navigation = navigation;
            ActiveCommand = new AsyncRelayCommand(OnClickActive);
            SuccessCommand = new AsyncRelayCommand(OnClickSuccess);
            CancelledCommand = new AsyncRelayCommand(OnClickCancelled);

            CompleteCommand = new AsyncRelayCommand<BookingDisplayDto>(
                async(arg) => await OnComplete(arg));
            CancelCommand = new AsyncRelayCommand<BookingDisplayDto>(
                async(arg) => await OnCancel(arg));

            this._databaseService = databaseService;
            CurrentBookingModels = new List<BookingDisplayDto>();
            CurrentPage = 1;
            InitData();
		}

		private async void InitData()
		{
			ActiveBookingModels = await GetBookingModel(BookingState.Active);
            CurrentBookingModels = ActiveBookingModels;
            updateButtonColor();
        }

		private async Task<List<BookingDisplayDto>> GetBookingModel(BookingState state)
		{
			List<BookingDisplayDto> Models = new List<BookingDisplayDto>();
            var bookingModels = await this._databaseService.GetBookingsByUser(this._databaseService.GetCurrentUser().UserId);

            foreach (var bookingModel in bookingModels)
            {
                if (bookingModel.State != state)
                {
                    continue;
                }
                var workerModel = _databaseService.GetWorkerByID(bookingModel.WorkerId);
                var serviceModel = _databaseService.GetServiceByID(bookingModel.ServiceId);

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
                ActiveBookingModels = await GetBookingModel(BookingState.Active);
            }
            CurrentBookingModels = ActiveBookingModels;
        }

        public async Task OnClickSuccess()
        {
            CurrentPage = 2;
            updateButtonColor();
            if (SuccessBookingModels is null || SuccessBookingModels.Count == 0)
            {
                SuccessBookingModels = await GetBookingModel(BookingState.Success);
            }
            CurrentBookingModels = SuccessBookingModels;
        }

        public async Task OnClickCancelled()
        {
            CurrentPage = 3;
            updateButtonColor();
            if (CancelBookingModels is null || CancelBookingModels.Count == 0)
            {
                CancelBookingModels = await GetBookingModel(BookingState.Cancelled);
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

        public async Task OnComplete(BookingDisplayDto booking)
        {
            var bookingModel = new BookingModel();
            bookingModel.BookingID = booking.BookingDto.BookingID;
            bookingModel.ServiceId = booking.BookingDto.ServiceId;
            bookingModel.ClientID = booking.BookingDto.ClientID;
            bookingModel.WorkerId = booking.BookingDto.WorkerId;
            bookingModel.StartDate = booking.BookingDto.StartDate;
            bookingModel.StartTime = booking.BookingDto.StartTime;
            bookingModel.WorkingHours = booking.BookingDto.WorkingHours;
            bookingModel.TotalPrice = booking.BookingDto.TotalPrice;
            bookingModel.Description = booking.BookingDto.Description;
            bookingModel.State = BookingState.Success;

            await _databaseService.UpdateBooking(_databaseService.GetCurrentUser().UserName, bookingModel);
        }

        public async Task OnCancel(BookingDisplayDto booking)
        {
            var bookingModel = new BookingModel();
            bookingModel.BookingID = booking.BookingDto.BookingID;
            bookingModel.ServiceId = booking.BookingDto.ServiceId;
            bookingModel.ClientID = booking.BookingDto.ClientID;
            bookingModel.WorkerId = booking.BookingDto.WorkerId;
            bookingModel.StartDate = booking.BookingDto.StartDate;
            bookingModel.StartTime = booking.BookingDto.StartTime;
            bookingModel.WorkingHours = booking.BookingDto.WorkingHours;
            bookingModel.TotalPrice = booking.BookingDto.TotalPrice;
            bookingModel.Description = booking.BookingDto.Description;
            bookingModel.State = BookingState.Cancelled;

            await _databaseService.UpdateBooking(_databaseService.GetCurrentUser().UserName, bookingModel);
        }
    }
}

