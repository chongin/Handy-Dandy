using System;
namespace Handy_Dandy.Models
{
	public class BookingModel
	{
		public BookingModel()
		{
		}

		public string OrderID { get; set; }
		public string ServiceID { get; set; }
		public string ClientID { get; set; }
		public string WorkderID { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public float TotalPrice { get; set; }
		public string Description { get; set; }
		public BookingState state { get; set; }
	}

	public enum BookingState
	{
		Opened = 1,
		Confirmed,
		Closed,
		Cancelled
	}
}

