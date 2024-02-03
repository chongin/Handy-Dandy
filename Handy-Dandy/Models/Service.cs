using System;
namespace Handy_Dandy.Models
{
	public class Service
	{
		public Service()
		{
		}

		public string ServiceID { get; set; }
		public string CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float ServiceCharge { get; set; }
		public int Discount { get; set; }
		public int Likes { get; set; }
	}
}

