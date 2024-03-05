using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class UserDto : ObservableObject
    {
        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Address { get; }
        public string Phone { get; }
        public string Avatar { get; }
        public bool IsMember { get; }
        public string City { get; }
        public int Balance { get; }
        public int RoleId { get; }
        public List<BookingModel> Bookings { get; }

        public UserDto(UserModel model)
		{
            UserId = model.UserId;
            UserName = model.UserName;
            Email = model.Email;
            Password = model.Password;
            Address = model.Address;
            Phone = model.Phone;
            RoleId = model.RoleId;
            IsMember = model.IsMember;
            Avatar = model.Avatar;
            City = model.City;
            Balance = model.Balance;
        }
	}
}

