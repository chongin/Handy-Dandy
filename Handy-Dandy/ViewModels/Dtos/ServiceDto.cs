using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class ServiceDto : ObservableObject
    {
        public string ServiceId { get; }
        public string CategoryId { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }
        public float ServiceCharge { get; }
        public int CompletedCount { get; }
        public float Score { get; }
        public List<string> WorkerIDs { get; }

        public ServiceDto(ServiceModel model)
		{
            ServiceId = model.ServiceId;
            CategoryId = model.CategoryId;
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

