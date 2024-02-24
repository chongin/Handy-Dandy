using System;
namespace Handy_Dandy.Models
{
	public class CountryModel
	{
        public string Name { get; set; }
        public CountryModel(string name)
        {
            this.Name = name;
        }
    }
}

