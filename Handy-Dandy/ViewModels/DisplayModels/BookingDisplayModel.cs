using System;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class BookingDisplayModel
	{
        public BookingModel BookingModel { get; set; }
        public WorkerModel WorkerModel { get; set; }
        public ServiceModel ServiceModel { get; set; }

        public string EndDateTime
        {
            get
            {
                return "3:00 PM - 5:00 PM";
            }
        }
    }
}

