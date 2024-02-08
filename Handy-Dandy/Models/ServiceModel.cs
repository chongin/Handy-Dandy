using System;
namespace Handy_Dandy.Models
{
	public class ServiceModel
	{
		public ServiceModel()
		{
		}

		public string ServiceID { get; set; }
		public string CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public string ImageName { get; set; }
        public int ServiceCharge { get; set; }
		public int CompletedCount { get; set; }
		public float Score { get; set; }

	}
}

