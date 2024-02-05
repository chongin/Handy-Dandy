using System;
namespace Handy_Dandy.Models
{
	public class User
	{
		public User()
		{
		}

		public string UserID { get; set; }
		public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

        public UserRole RoleID { get; set; }
        public List<Order> Orders { get; set; }
	}

	public enum UserRole
	{
		Admin = 1,
		Client,
		Workder
	}
}

