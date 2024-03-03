using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class BookingDto : ObservableObject
    {
        public string BookingID { get; }
        public string ServiceId { get; }
        public string ClientID { get; }
        public string WorkerId { get; }
        public string StartDate { get; }
        public string StartTime { get; }
        public int WorkingHours { get; }
        public float TotalPrice { get; }
        public string Description { get; }
        public BookingState State { get; }

        public BookingDto(BookingModel model)
		{
            BookingID = model.BookingID;
            ServiceId = model.ServiceId;
            ClientID = model.ClientID;
            WorkerId = model.WorkerId;
            StartDate = model.StartDate;
            StartTime = model.StartTime;
            WorkingHours = model.WorkingHours;
            TotalPrice = model.TotalPrice;
            Description = model.Description;
            State = model.State;
        }

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
}

