using System;
using Firebase.Database;
using Firebase.Database.Query;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels;
using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Handy_Dandy.Services
{
	public class FireBaseService: IDatabaseService1
    {
        private readonly FirebaseClient _firebase;
		private static string UserRootName = "Clients";
        private static string CategoriesRootName = "categories";
        private static string ServiceWorkersRootName = "service_workers";
        private static string WorkersRootName = "workers";
        private static string BookingRootName = "bookings";

        private List<string> serviceImageNames;
        private List<string> serviceNames;
        List<string> categoryImageNames;
        List<string> categoryName;

        private List<CategoryModel> _categories;
        private List<WorkerModel> _workers;
        private List<ServiceWorkerModel> _serviceWorkers;
        public FireBaseService(string firebaseUrl)
		{
            _categories = new List<CategoryModel>();
            _workers = new List<WorkerModel>();
            _serviceWorkers = new List<ServiceWorkerModel>();

            _firebase = new FirebaseClient(firebaseUrl);
          
            Console.WriteLine("Init data success.");
        }

        public async Task InitData()
        {
            this._categories = await GetCategoriesAsync();
            this._serviceWorkers = await GetServiceWorkerModelsAsync();
            this._workers = await GetWorkerModelsAsync();
        }

        List<CategoryModel> GetCategories()
        {
            return this._categories;
        }
        #region User
        public async Task InserUser(UserModel user)
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

		public async Task UpdateUser(UserModel user)
		{
			var userRef = this._firebase.Child(UserRootName).Child(user.UserId);
			await userRef.PutAsync(user);
        }

        public async Task<UserModel> QueryUserByEmail(string email)
        {
            try
            {
                var userRef = this._firebase.Child(UserRootName);
                var userSnapshot = await userRef.OnceAsync<UserModel>();

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

 
        public async Task<UserModel> GetUserById(string userId)
        {
            try
            {
                var userRef = this._firebase.Child(UserRootName);
                var userSnapshot = await userRef.OnceAsync<UserModel>();

                var user = userSnapshot.FirstOrDefault(u => u.Object.UserId == userId);

                if (user != null)
                {
                    return user.Object;
                }
                else
                {
                    Console.WriteLine($"User with UserId: {userId} not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying user with UserId: {userId}. Exception: {ex.Message}");
                return null;
            }
        }
        #endregion


        #region Categories
        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            try
            {
                var json = await _firebase.Child(CategoriesRootName).OnceSingleAsync<JObject>();
                foreach (var category in json)
                {
                    var categoryJson = category.Value.ToString();
                    var categoryModel = JsonConvert.DeserializeObject<CategoryModel>(categoryJson);
                    categories.Add(categoryModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCategories error. Exception: {ex.Message}");
                throw;
            }

            return categories;
        }
        #endregion

        public async Task<List<ServiceWorkerModel>> GetServiceWorkerModelsAsync()
        {
            List<ServiceWorkerModel> serviceWorkerModels = new List<ServiceWorkerModel>();
            try
            {
                var json = await _firebase.Child(ServiceWorkersRootName).OnceSingleAsync<JObject>();
                foreach (var serviceWorker in json)
                {
                    var serviceWorkerJson = serviceWorker.Value.ToString();
                    var serviceWorkerModel = JsonConvert.DeserializeObject<ServiceWorkerModel>(serviceWorkerJson);
                    serviceWorkerModels.Add(serviceWorkerModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetServiceWorkerModels error. Exception: {ex.Message}");
                throw;
            }

            return serviceWorkerModels;
        }

        public async Task<List<WorkerModel>> GetWorkerModelsAsync()
        {
            List<WorkerModel> workerModels = new List<WorkerModel>();
            try
            {
                var json = await _firebase.Child(WorkersRootName).OnceSingleAsync<JObject>();
                foreach (var worker in json)
                {
                    var workerJson = worker.Value.ToString();
                    var workerModel = JsonConvert.DeserializeObject<WorkerModel>(workerJson);
                    workerModels.Add(workerModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetWorkerModels error. Exception: {ex.Message}");
                throw;
            }

            return workerModels;
        }
    }
}

