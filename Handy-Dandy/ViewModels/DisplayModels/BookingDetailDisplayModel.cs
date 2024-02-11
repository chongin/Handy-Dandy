using System;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class BookingDetailDisplayModel
	{
		public BookingDetailDisplayModel()
		{
		}

		public BookingModel BookingModel { get; set; }
		public ServiceModel ServiceModel { get; set; }
	}
}

