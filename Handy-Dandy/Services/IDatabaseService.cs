using System;
using Handy_Dandy.Models;
namespace Handy_Dandy.Services
{
	public interface IDatabaseService
	{
		Task InserUser(UserModel user);
		Task UpdateUser(UserModel user);
		Task<UserModel> QueryUserByEmail(string email);
    }
}

