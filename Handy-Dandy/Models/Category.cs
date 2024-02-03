using System;
namespace Handy_Dandy.Models
{
	public class Category
	{
		public Category()
		{
		}

		public int CategoryID { get; set; }
		public string Name { get; set; }
		public List<Service> Services { get; set; }
	}
}

