using System;
namespace Handy_Dandy.Models
{
	public class OrderModel
	{
		public OrderModel()
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
		public OrderState state { get; set; }
	}

	public enum OrderState
	{
		Opened = 1,
		Confirmed,
		Closed,
		Cancelled
	}
}

