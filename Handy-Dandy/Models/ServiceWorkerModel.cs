using System;
using Newtonsoft.Json;

namespace Handy_Dandy.Models
{
    public class ServiceWorkerModel
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("service_name")]
        public string ServiceName { get; set; }

        [JsonProperty("worker_ids")]
        public List<string> WorkerIds { get; set; }
    }
}