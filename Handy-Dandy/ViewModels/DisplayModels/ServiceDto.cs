using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class ServiceDto : ObservableObject
    {
        public string ServiceID { get; }
        public string CategoryID { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }
        public int ServiceCharge { get; }
        public int CompletedCount { get; }
        public float Score { get; }
        public List<string> WorkerIDs { get; }

        public ServiceDto(ServiceModel model)
		{
            ServiceID = model.ServiceID;
            CategoryID = model.CategoryID;
            Name = model.Name;
            Description = model.Description;
            ImageName = model.ImageName;
            ServiceCharge = model.ServiceCharge;
            CompletedCount = model.CompletedCount;
            Score = model.Score;
            WorkerIDs = new List<string>();
            WorkerIDs = model.WorkerIDs;
        }
	}
}

