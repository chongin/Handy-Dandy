using System;
namespace Handy_Dandy.Models
{
	public class CategoryModel
	{
		public CategoryModel()
		{
		}

		public string CategoryID { get; set; }
		public string Name { get; set; }
		public string CategoryImage { get; set; }
		public List<ServiceModel> Services { get; set; }
	}
}

