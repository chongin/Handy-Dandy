using System;
using Firebase.Database;
using Firebase.Database.Query;
using Handy_Dandy.Models;

namespace Handy_Dandy.Services
{
	public class FireBaseService
	{
        private readonly FirebaseClient _firebase;
		private static string UserRootName = "Clients";
        public FireBaseService(string firebaseUrl)
		{
            _firebase = new FirebaseClient(firebaseUrl);
		}

		public async Task InserUser(User user)
		{
			var result = await this._firebase.Child(UserRootName).PostAsync(user);
			if (result.Key != null)
			{
				Console.WriteLine("Success to insert data into Firebase");
            }
			else
			{
                Console.WriteLine("Failed to insert data into Firebase");
            }
		}

		public async Task UpdateUser(User user)
		{
			var userRef = this._firebase.Child(UserRootName).Child(user.UserID);
			await userRef.PutAsync(user);
        }

        public async Task<User> QueryUserByEmail(string email)
        {
            try
            {
                var userRef = this._firebase.Child(UserRootName);
                var userSnapshot = await userRef.OnceAsync<User>();

                var user = userSnapshot.FirstOrDefault(u => u.Object.Email == email);

                if (user != null)
                {
                    return user.Object;
                }
                else
                {
                    Console.WriteLine($"User with Email: {email} not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying user with Email: {email}. Exception: {ex.Message}");
                return null;
            }
        }
    }
}

