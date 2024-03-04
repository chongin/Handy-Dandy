using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;
using Newtonsoft.Json;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class ServiceWorkerDto : ObservableObject
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public List<string> WorkerIds { get; set; }

        public ServiceWorkerDto(ServiceWorkerModel serviceWorkerModel)
		{
            ServiceId = serviceWorkerModel.ServiceId;
            ServiceName = serviceWorkerModel.ServiceName;
            WorkerIds = new List<string>();
            WorkerIds = serviceWorkerModel.WorkerIds;
        }
    }
}

