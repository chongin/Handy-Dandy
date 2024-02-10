using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Handy_Dandy.Models;
using Handy_Dandy.ViewModels;
using Handy_Dandy.Services;

namespace Handy_Dandy.ViewModels
{
    public class CombineBookingModel
    {
        public BookingModel BookingModel { get; set; }
        public WorkerModel WorkerModel { get; set; }
        public ServiceModel ServiceModel { get; set; }
    }

    public partial class BookingViewModel: BaseViewModel
	{
		private IDatabaseService _databaseService;

	
		public List<CombineBookingModel> ActiveCombineBookingModels { get; set; }
        public List<CombineBookingModel> SuccessCombineBookingModels { get; set; }
        public List<CombineBookingModel> CancelCombineBookingModels { get; set; }

        private List<CombineBookingModel> _currentCombineBookingModels;
        public List<CombineBookingModel> CurrentCombineBookingModels
        {
            get => _currentCombineBookingModels;
            set => SetProperty(ref _currentCombineBookingModels, value);
        }

        public int CurrentPage { get; set; }

        public IAsyncRelayCommand ActiveCommand { get; }
        public IAsyncRelayCommand SuccessCommand { get; }
        public IAsyncRelayCommand CancelledCommand { get; }

        public BookingViewModel(IDatabaseService databaseService)
		{
            ActiveCommand = new AsyncRelayCommand(OnClickActive);
            SuccessCommand = new AsyncRelayCommand(OnClickSuccess);
            CancelledCommand = new AsyncRelayCommand(OnClickCancelled);

            this._databaseService = databaseService;
            CurrentCombineBookingModels = new List<CombineBookingModel>();
            CurrentPage = 1;
            InitData();
		}

		private async void InitData()
		{
			ActiveCombineBookingModels = await GetCombineBookingModel("Active");
            CurrentCombineBookingModels.Clear();
            foreach (var model in ActiveCombineBookingModels)
            {
                CurrentCombineBookingModels.Add(model);
            }
            
        }

		private async Task<List<CombineBookingModel>> GetCombineBookingModel(string state)
		{
			List<CombineBookingModel> combineModels = new List<CombineBookingModel>();
            var bookingModels = await this._databaseService.GetBookingsByState(state);
            foreach (var bookingModel in bookingModels)
            {
                var workerModel = await this._databaseService.GetWorkerByID(bookingModel.WorkderID);
                var serviceModel = await this._databaseService.GetServiceByID(bookingModel.ServiceID);

                CombineBookingModel combineModel = new CombineBookingModel();
                combineModel.BookingModel = bookingModel;
                combineModel.WorkerModel = workerModel;
                combineModel.ServiceModel = serviceModel;
                combineModels.Add(combineModel);
            }
			return combineModels;
        }

        public async Task OnClickActive()
        {
            CurrentPage = 1;
            ActiveCombineBookingModels = await GetCombineBookingModel("Active");
            CurrentCombineBookingModels = ActiveCombineBookingModels;
        }

        public async Task OnClickSuccess()
        {
            CurrentPage = 2;
            SuccessCombineBookingModels = await GetCombineBookingModel("Success");
            CurrentCombineBookingModels = SuccessCombineBookingModels;
        }

        public async Task OnClickCancelled()
        {
            CurrentPage = 3;
            CancelCombineBookingModels = await GetCombineBookingModel("Cancelled");
            CurrentCombineBookingModels = CancelCombineBookingModels;
        }
    }
}

