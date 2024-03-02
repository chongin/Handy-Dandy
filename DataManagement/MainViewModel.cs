using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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
                    OnPropertyChanged();
                }
            }
        }

        private string _servicePath;

        public string ServicePath
        {
            get => _servicePath;
            set
            {
                if (_servicePath != value)
                {
                    _servicePath = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }


        public ICommand SelectCategoryCommand { get; private set; }
        public ICommand SelectServiceCommand { get; private set; }
        public ICommand SelectServiceWorkerCommand { get; private set; }

        public ICommand ConfirmCommand { get; private set; }

        public MainViewModel()
        {

            SelectCategoryCommand = new Command(OnCategoryButtonClick);
            SelectServiceCommand = new Command(OnServiceButtonClick);
            SelectServiceWorkerCommand = new Command(OnServiceWorkerButtonClick);
            ConfirmCommand = new Command(OnConfirmButtonClick);

        }

        private void OnCategoryButtonClick()
        {

        }

        private void OnServiceButtonClick()
        {

        }

        private void OnServiceWorkerButtonClick()
        {

        }

        private void OnConfirmButtonClick()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
