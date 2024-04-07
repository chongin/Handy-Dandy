using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels.Dtos;
using Handy_Dandy.Services;
using Handy_Dandy.Views;
using System.Windows.Input;
using Firebase.Database;

namespace Handy_Dandy.ViewModels
{
    [QueryProperty("Category", "Category")]
    public partial class BookingDetailViewModel : BaseViewModel
    {

        [ObservableProperty]
        ServiceDto service;

        [ObservableProperty]
        private BookingDetailDto bookingDetailDisplay;

        [ObservableProperty]
        private string workingHours = "1";

        [ObservableProperty]
        private string subTotal = "";

        [ObservableProperty]
        private string estimatedTax = "";

        [ObservableProperty]
        private List<DateDisplayModel> next7Dates = new List<DateDisplayModel>();

        [ObservableProperty]
        private List<TimeDisplayModel> startWorkTimes = new List<TimeDisplayModel>();

        public IAsyncRelayCommand TabTimeCommand { get; }
        public IAsyncRelayCommand TabDateCommand { get; }
        public IAsyncRelayCommand TabWorkerCommand { get; }
        public IAsyncRelayCommand BackCommand { get; }

        public IAsyncRelayCommand HoursSelectedCommand { get; }

        public IAsyncRelayCommand ConfirmCommand { get; }

        private int currentSelectTimeIndex = -1;
		private int currentSelectDateIndex = -1;
		private int currentSelectWorkerIndex = -1;

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

            HoursSelectedCommand = new AsyncRelayCommand(async (arg) => await OnHoursSelected(arg));

            ConfirmCommand = new AsyncRelayCommand(OnConfirmed);
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
            int daysToAdd = 10;

            for (int i = 1; i < daysToAdd; i++)
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
            if (currentSelectTimeIndex >= 0)
            {
                var preTime = StartWorkTimes[currentSelectTimeIndex];
                preTime.CurrentColor = Color.FromArgb("#00000000");
            }


            int currentIndex = StartWorkTimes.IndexOf(timeModel);
            timeModel.CurrentColor = Color.FromRgb(35, 206, 250);

            currentSelectTimeIndex = currentIndex;
        }

        private async Task OnTabDate(DateDisplayModel dateModel)
        {
            if (currentSelectDateIndex >= 0)
            {
                var preDate = Next7Dates[currentSelectDateIndex];
                preDate.CurrentColor = Color.FromArgb("#00000000");
            }


            int currentIndex = Next7Dates.IndexOf(dateModel);
            dateModel.CurrentColor = Color.FromRgb(35, 206, 250);

            currentSelectDateIndex = currentIndex;
        }

        private async Task OnTabWorker(WorkerDto workerDto)
        {
            if (currentSelectWorkerIndex >= 0)
            {
                var preWorker = BookingDetailDisplay.WorkerDtos[currentSelectWorkerIndex];
                preWorker.CurrentColor = Color.FromArgb("#00000000");
            }

            int currentIndex = BookingDetailDisplay.WorkerDtos.IndexOf(workerDto);
            workerDto.CurrentColor = Color.FromRgb(35, 206, 250);

            currentSelectWorkerIndex = currentIndex;

            UpdateMoney();
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
            var cost = TotalPrice();
            bool result = await Shell.Current.CurrentPage.DisplayAlert("Confirmation", $"Your booking will takes you: {cost}\nAre you sure?", "Yes", "No");

            if (result)
            {

                var currentWorker = BookingDetailDisplay.WorkerDtos[currentSelectWorkerIndex];
                var currTime = StartWorkTimes[currentSelectTimeIndex];
                BookingModel model = new BookingModel();
                model.BookingID = Guid.NewGuid().ToString();
                model.ServiceId = Service.ServiceId;
                model.ClientID = "7ed249e2-072a-43b0-a7e8-b7997a22cdea";
                model.WorkerId = currentWorker.WorkerId;
                model.StartDate = "";
                model.StartTime = currTime.ToString();
                model.WorkingHours = int.Parse(WorkingHours);
                model.TotalPrice = TotalPrice();
                model.Description = "a new Booking";
                model.State = BookingState.Active;

                var username = "chongin";
                await _databaseService1.InserBooking(username, model);
            }
            else
            {
            }
        }

        private async Task OnHoursSelected(object obj)
        {
            string s = WorkingHours;
            Console.WriteLine(s);
            UpdateMoney();
        }

        private void UpdateMoney()
        {
            if (currentSelectWorkerIndex >= 0)
            {
                var currentWorker = BookingDetailDisplay.WorkerDtos[currentSelectWorkerIndex];
                int hours = int.Parse(WorkingHours);
                decimal total = currentWorker.LaborCost * hours;
                decimal tax = total * 0.13m;
                SubTotal = $"${total}";
                EstimatedTax = $"${tax}";
            }
        }

        private float TotalPrice()
        {
            var currentWorker = BookingDetailDisplay.WorkerDtos[currentSelectWorkerIndex];
            int hours = int.Parse(WorkingHours);
            decimal total = currentWorker.LaborCost * hours;
            decimal tax = total * 0.13m;
            var cost = total + tax;
            return (float)cost;
        }
    }
}


