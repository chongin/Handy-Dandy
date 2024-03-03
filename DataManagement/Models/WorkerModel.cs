using System;
using Newtonsoft.Json;

namespace DataManagement.Models
{
    public class WorkerModel
    {
        [JsonProperty("worker_id")]
        public string WorkerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("ratings")]
        public int Ratings { get; set; }

        [JsonProperty("labor_cost")]
        public int LaborCost { get; set; }

        [JsonProperty("image_name")]
        public string ImageName { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }
    }
}

