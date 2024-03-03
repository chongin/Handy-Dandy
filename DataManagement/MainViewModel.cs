using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataManagement.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace DataManagement
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _categoryPath;

        public string CategorPath
        {
            get => _categoryPath;
            set
            {
                if (_categoryPath != value)
                {
                    _categoryPath = value;
                    OnPropertyChanged(nameof(CategorPath));
                }
            }
        }

        private string _workerPath;

        public string WorkerPath
        {
            get => _workerPath;
            set
            {
                if (_workerPath != value)
                {
                    _workerPath = value;
                    OnPropertyChanged(nameof(WorkerPath));
                }
            }
        }

        private string _serviceWorkerPath;

        public string ServiceWorkerPath
        {
            get => _serviceWorkerPath;
            set
            {
                if (_serviceWorkerPath != value)
                {
                    _serviceWorkerPath = value;
                    OnPropertyChanged(nameof(ServiceWorkerPath));
                }
            }
        }

        private double uploadProgress;
        public double UploadProgress
        {
            get { return uploadProgress; }
            set
            {
                if (uploadProgress != value)
                {
                    uploadProgress = value;
                    OnPropertyChanged(nameof(UploadProgress));
                }
            }
        }

        private bool _enableConfirm;

        public bool EnableConfirm
        {
            get => _enableConfirm;
            set
            {
                if (_enableConfirm != value)
                {
                    _enableConfirm = value;
                    OnPropertyChanged(nameof(EnableConfirm));
                }
            }
        }

        public ICommand SelectCategoryCommand { get; private set; }
        public ICommand SelectWorkerCommand { get; private set; }
        public ICommand SelectServiceWorkerCommand { get; private set; }
        private FirebaseClient _firebaseClient;
        public ICommand ConfirmCommand { get; private set; }

        public MainViewModel()
        {
            _enableConfirm = false;
            _firebaseClient = new FirebaseClient("https://handy-dandy-1ce26-default-rtdb.firebaseio.com/");
            SelectCategoryCommand = new Command(OnCategoryButtonClickAsync);
            SelectWorkerCommand = new Command(OnWorkerButtonClick);
            SelectServiceWorkerCommand = new Command(OnServiceWorkerButtonClick);
            ConfirmCommand = new Command(OnConfirmButtonClick);

        }

        private async void OnCategoryButtonClickAsync()
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a JSON file"
            });
            CategorPath = file.FullPath;
            CheckConfirmEnable();
        }

        private async void OnWorkerButtonClick()
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a JSON file"
            });
            WorkerPath = file.FullPath;
            CheckConfirmEnable();
        }

        private async void OnServiceWorkerButtonClick()
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a JSON file"
            });
            ServiceWorkerPath = file.FullPath;
            CheckConfirmEnable();
        }

        private void CheckConfirmEnable()
        {
            if (CategorPath.Length > 0 && WorkerPath.Length > 0 && ServiceWorkerPath.Length > 0)
            {
                EnableConfirm = true;
            }
            else
            {
                EnableConfirm = false;
            }
        }
        private async void OnConfirmButtonClick()
        {
            int totalTasks = 3;

            int taskNum = 0;

            await UploadCategoryData();
            taskNum += 1;
            UploadProgress = taskNum / (double)totalTasks;

            await UploadWorkerData();
            taskNum += 1;
            UploadProgress = taskNum / (double)totalTasks;

            await UploadServiceWorkerData();
            taskNum += 1;
            UploadProgress = taskNum / (double)totalTasks;

            await Shell.Current.CurrentPage.DisplayAlert("Success", "Data successfully uploaded to Firebase!", "OK");
        }


        private async Task UploadCategoryData()
        {
            string jsonText = File.ReadAllText(_categoryPath);
            AppData categoriesData = JsonConvert.DeserializeObject<AppData>(jsonText);
            foreach (var category in categoriesData.Categories)
            {
                await _firebaseClient.Child("categories").Child(category.CategoryId).PutAsync(category);
            }
        }

        private async Task UploadWorkerData()
        {
            string jsonText = File.ReadAllText(_workerPath);
            AppData workersData = JsonConvert.DeserializeObject<AppData>(jsonText);
            foreach (var worker in workersData.Workers)
            {
                await _firebaseClient.Child("workers").Child(worker.WorkerID).PutAsync(worker);
            }
        }

        private async Task UploadServiceWorkerData()
        {
            string jsonText = File.ReadAllText(_serviceWorkerPath);
            AppData serviceWorkersData = JsonConvert.DeserializeObject<AppData>(jsonText);
            foreach (var serviceWorker in serviceWorkersData.ServiceWorkers)
            {
                await _firebaseClient.Child("service_workers").Child(serviceWorker.ServiceId).PutAsync(serviceWorker);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
