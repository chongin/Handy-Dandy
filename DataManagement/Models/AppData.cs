using System;
using Newtonsoft.Json;

using System;
using Newtonsoft.Json;

namespace DataManagement.Models
{
    public class AppData
    {
        [JsonProperty("categories")]
        public List<CategoryModel> Categories { get; set; }

        [JsonProperty("workers")]
        public List<WorkerModel> Workers { get; set; }

        [JsonProperty("service_workers")]
        public List<ServiceWorkerModel> ServiceWorkers { get; set; }
    }
}


