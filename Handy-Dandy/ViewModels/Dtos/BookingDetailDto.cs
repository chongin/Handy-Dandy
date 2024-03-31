using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class BookingDetailDto: ObservableObject
    {
		public BookingDetailDto()
		{
		}

		//public BookingDto BookingDto { get; set; }
		public ServiceDto ServiceDto { get; set; }
		public List<WorkerDto> WorkerDtos { get; set; }

		public string ServiceCharge
		{
			get
			{
				return $"${ServiceDto.ServiceCharge}";
			}
		}

		public string CompletedCount
		{
			get
			{
				return $"({ServiceDto.CompletedCount})";
			}
		}
		public List<string> ScoreImages
		{
			get
			{
				List<string> imageNames = new List<string>();
				for (int i = 0; i < (int)ServiceDto.Score; ++i)
				{
					imageNames.Add("score");
				}
				return imageNames;
			}
		}
	}
}

