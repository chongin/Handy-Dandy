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
    }

    public class BookingViewModel: BaseViewModel
	{
		private IDatabaseService _databaseService;

	
		public List<CombineBookingModel> ActiveCombineBookingModels { get; set; }
        public List<CombineBookingModel> SuccessCombineBookingModels { get; set; }
        public List<CombineBookingModel> CancelCombineBookingModels { get; set; }
        public List<CombineBookingModel> CurrentCombineBookingModels { get; set; }

        public int CurrentPage { get; set; }

        public BookingViewModel(IDatabaseService databaseService)
		{
			this._databaseService = databaseService;
            CurrentCombineBookingModels = new List<CombineBookingModel>();
            CurrentPage = 1;
            InitData();
		}

		private async void InitData()
		{
			ActiveCombineBookingModels = await GetCombineBookingModel("Active");
            SuccessCombineBookingModels = await GetCombineBookingModel("Success");
            CancelCombineBookingModels = await GetCombineBookingModel("Cancelled");

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
                var workerModel = await this._databaseService.GetWorkersByID(bookingModel.WorkderID);
                CombineBookingModel combineModel = new CombineBookingModel();
                combineModel.BookingModel = bookingModel;
                combineModel.WorkerModel = workerModel;

                combineModels.Add(combineModel);
            }
			return combineModels;
        }
    }
}

