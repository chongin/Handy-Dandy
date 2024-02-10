using System;
namespace Handy_Dandy.Models
{
	public class BookingModel
	{
		public BookingModel()
		{
		}

        public static BookingState ConvertBookingState(string stateString)
		{
            BookingState bookingState;
            if (Enum.TryParse(stateString, out bookingState))
            {
                return bookingState;
            }
            else
            {
                throw new ArgumentException($"Invalid booking state string: {stateString}");
            }
        }

        public string BookingID { get; set; }
		public string ServiceID { get; set; }
		public string ClientID { get; set; }
		public string WorkderID { get; set; }
		public string StartDate { get; set; }
		public string StartTime { get; set; }
		public int WorkingHours { get; set; }
		public float TotalPrice { get; set; }
		public string Description { get; set; }
		public BookingState State { get; set; }


        public string StateName
        {
            get
            {
                return State.ToString();
            }
        }

		public int Year
		{
			get
			{
				if (DateTime.TryParse(StartDate, out DateTime date))
				{
					return date.Year;
				}
				else
				{
					return -1;
				}
			}
		}

        public int Month
        {
            get
            {
                if (DateTime.TryParse(StartDate, out DateTime date))
                {
                    return date.Month;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int Date
        {
            get
            {
                if (DateTime.TryParse(StartDate, out DateTime date))
                {
                    return date.Day;
                }
                else
                {
                    return -1;
                }
            }
        }
    }

	public enum BookingState
	{
		Active = 1,
		Success,
		Cancelled
	}
}

