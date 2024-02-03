﻿using System;
namespace Handy_Dandy.Models
{
	public class UserBasicInfo
	{
		public UserBasicInfo()
		{
		}

		public string UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UserRole RoleID { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }

		public List<Order> Orders { get; set; }
	}

	public enum UserRole
	{
		Admin = 1,
		Client,
		Workder
	}

	public class Client: UserBasicInfo
	{
		public Client()
		{

		}
	}

    public class Workder : UserBasicInfo
    {
        public Workder()
        {

        }
    }
}

