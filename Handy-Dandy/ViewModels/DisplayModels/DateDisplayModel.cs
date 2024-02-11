using System;
namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class DateDisplayModel
	{
		public DateTime DateTime;
		public DateDisplayModel(DateTime dateTime)
		{
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

