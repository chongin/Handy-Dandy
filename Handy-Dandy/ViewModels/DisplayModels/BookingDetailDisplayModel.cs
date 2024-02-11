using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class BookingDetailDisplayModel: ObservableObject
    {
		public BookingDetailDisplayModel()
		{
		}

		public BookingModel BookingModel { get; set; }
		public ServiceModel ServiceModel { get; set; }
		public List<WorkerModel> Workers { get; set; }

		public string ServiceCharge
		{
			get
			{
				return $"${ServiceModel.ServiceCharge}";
			}
		}

		public string CompletedCount
		{
			get
			{
				return $"({ServiceModel.CompletedCount})";
			}
		}
		public List<string> ScoreImages
		{
			get
			{
				List<string> imageNames = new List<string>();
				for (int i = 0; i < (int)ServiceModel.Score; ++i)
				{
					imageNames.Add("score");
				}
				return imageNames;
			}
		}
	}
}

