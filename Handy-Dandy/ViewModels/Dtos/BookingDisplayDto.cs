using System;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class BookingDisplayDto
	{
        public BookingDto BookingDto { get; set; }
        public WorkerDto WorkerDto { get; set; }
        public ServiceDto ServiceDto { get; set; }

        public string EndDateTime
        {
            get
            {
                return "3:00 PM - 5:00 PM";
            }
        }
    }
}

