using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Handy_Dandy.Models;
using System.Windows.Input;

namespace Handy_Dandy.ViewModels
{
	public partial class HomePageViewModel: ObservableObject
    {
		public ObservableCollection<IntroduceServices> IntroServices { get; set; }
        private string _buttonText = "Next";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        [ObservableProperty]
        private int position;

        private int PreviousPosition = 0;
        private int CurrentPosition = 0;

        public IAsyncRelayCommand CarouselPositionChangedCommand { get; }

        public ICommand PositionChangedCommand => new Command<int>((position) =>
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
        });

        public HomePageViewModel()
		{
			this.IntroServices = new ObservableCollection<IntroduceServices>();
            
            InitData();
            CarouselPositionChangedCommand = new AsyncRelayCommand<int>(async (currentPosition) => await OnCarouselPositionChanged(currentPosition));
        }

		public void InitData()
		{
			IntroServices.Add(new IntroduceServices {
				IntroTitle ="Cleaning",
				IntroDescription="Best Cleaning",
				IntroImage="cleaning"
			});

            IntroServices.Add(new IntroduceServices
            {
                IntroTitle = "Repairing",
                IntroDescription = "Best Repairing",
                IntroImage = "repairing"
            });

            IntroServices.Add(new IntroduceServices
            {
                IntroTitle = "Painting",
                IntroDescription = "Best Painting",
                IntroImage = "painting"
            });
        }

        private async Task OnCarouselPositionChanged(int currentPosition)
        {
            // UpdateButtonText();
            Console.WriteLine($"current position: {currentPosition}");
            await Task.Yield();
        }

        private void UpdatePosition()
        {
            //
        }
    }
}

