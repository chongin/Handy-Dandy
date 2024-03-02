using System;
using Newtonsoft.Json;

namespace DataManagement.Models
{
	public class CategoryModel
	{
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category_image")]
        public string CategoryImage { get; set; }

        [JsonProperty("services")]
        public List<ServiceModel> Services { get; set; }
    }
}

