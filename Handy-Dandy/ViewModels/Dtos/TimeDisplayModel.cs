using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class TimeDisplayModel: ObservableObject
    {
		public String Time { get; set; }
		private Color _currentColor;
		public Color CurrentColor
		{
			get => _currentColor;
			set => SetProperty(ref _currentColor, value);
		}

		public TimeDisplayModel(int hour)
		{
            _currentColor = Color.FromArgb("#00000000");
            Time = hour < 12 ? $"{hour}:00 AM" : $"{hour}:00 PM";
        }
	}
}

