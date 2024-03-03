using System;
namespace Handy_Dandy.Models
{
	public class UserModel
	{
		public UserModel()
		{
		}

		public string UserId { get; set; }
		public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
        public string Avatar { get; set; }
        public bool IsMember { get; set; }
		public string City { get; set; }
		public int Balance { get; set; }
        public int RoleId { get; set; }
        public List<BookingModel> Orders { get; set; }
	}

	public enum UserRole
	{
		Admin = 1,
		Client,
		Workder
	}
}

