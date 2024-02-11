using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class DateDisplayModel : ObservableObject
    {
		public DateTime DateTime;
        private Color _currentColor;
        public Color CurrentColor
        {
            get => _currentColor;
            set => SetProperty(ref _currentColor, value);
        }

        public DateDisplayModel(DateTime dateTime)
		{
            _currentColor = Color.FromArgb("#00000000");
            this.DateTime = dateTime;
		}

		public string Month
		{
			get
			{
				return DateTime.ToString("MMM");
			}
		}

		public string DateOfWeek
		{
			get
			{
				return DateTime.ToString("ddd");
			}
		}

		public int Day
		{
			get
			{
				return DateTime.Day;
			}
		}
	}
}

