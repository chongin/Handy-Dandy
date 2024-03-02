using System;
using Newtonsoft.Json;

namespace DataManagement.Models
{
	public class AppData
	{
        [JsonProperty("categories")]
        public List<CategoryModel> Categories { get; set; }
    }
}

