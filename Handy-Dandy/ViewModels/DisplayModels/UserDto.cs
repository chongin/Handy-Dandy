using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class UserDto : ObservableObject
    {
        public string UserID { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Address { get; }
        public string Phone { get; }

        public UserRole RoleID { get; }
        public List<BookingModel> Bookings { get; }

        public UserDto(UserModel model)
		{
            UserID = model.UserID;
            UserName = model.UserName;
            Email = model.Email;
            Password = model.Password;
            Address = model.Address;
            Phone = model.Phone;
            RoleID = model.RoleID;
        }
	}
}

