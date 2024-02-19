using System;
namespace Handy_Dandy.Models
{
	public class AddressModel
	{
		public AddressModel()
		{
		}
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
	}
}

