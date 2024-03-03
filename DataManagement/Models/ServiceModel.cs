using System;
using Newtonsoft.Json;

namespace DataManagement.Models
{
	public class ServiceModel
	{
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_name")]
        public string ImageName { get; set; }

        [JsonProperty("service_charge")]
        public float ServiceCharge { get; set; }

        [JsonProperty("completed_count")]
        public int CompletedCount { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }
    }
}

