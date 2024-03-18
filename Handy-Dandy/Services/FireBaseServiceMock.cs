using System;
using Firebase.Database;
using Firebase.Database.Query;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels;
using Bogus;

namespace Handy_Dandy.Services
{
	public class FireBaseServiceMock: IDatabaseService
	{
        private readonly FirebaseClient _firebase;
		private static string UserRootName = "Clients";
        private List<string> serviceImageNames;
        private List<string> serviceNames;
        List<string> categoryImageNames;
        List<string> categoryName;
        public FireBaseServiceMock(string firebaseUrl)
		{
            _firebase = new FirebaseClient(firebaseUrl);

            categoryImageNames = new List<string> { "category_cleaning", "category_repairing", "category_beauty" };
            categoryName = new List<string> { "Cleaning", "Repairing", "Beauty" };

            serviceImageNames = new List<string> { "sercie_clean_floor", "service_clean_ac", "service_clean_wall",
                "service_laundry", "service_maintain_light", "service_repair_appliance"};

            serviceNames = new List<string> { "Clean Floor", "Clean AC", "Clean Wall",
                "Laundry", "Maintain Light", "Repair Appliance"};

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
            var faker = new Faker();
            UserModel model = new UserModel();
            model.UserId = userId;
            model.UserName = faker.Name.FullName();
            model.Email = $"{model.UserName}@gmail.com";
            model.Password = faker.Random.AlphaNumeric(10);
            model.Address = faker.Address.FullAddress();
            model.Phone = faker.Phone.PhoneNumber();
            model.IsMember = false;
            model.RoleId = (int)UserRole.Client;
            model.Avatar = "dotnet_bot";
            model.City = faker.Address.City();
            model.Balance = faker.Random.Int(0, 100);
            return model;
        }
        #endregion


        #region Categories
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            for (int i = 0; i < 9; ++i)
            {
                categories.Add(CreateCategoryModel(i));
            }

            //await Task.Yield();
            return categories;
        }

        private CategoryModel CreateCategoryModel(int index)
        {
            Random random = new Random();
            int randomNameIndex = random.Next(categoryImageNames.Count);
            CategoryModel category = new CategoryModel
            {
                CategoryId = $"C{index}_{randomNameIndex}",
                Name = $"{categoryName[randomNameIndex]}{index}",
                CategoryImage = $"{categoryImageNames[randomNameIndex]}",
                Services = new List<ServiceModel>()
            };

            

            int numberOfServices = random.Next(3, 11);

            var faker = new Faker();
            for (int j = 0; j < numberOfServices; j++)
            {
                int randomIndex = random.Next(serviceNames.Count);
                ServiceModel service = new ServiceModel
                {
                    ServiceId = $"{category.CategoryId}_S{j}",
                    CategoryId = category.CategoryId,
                    Name = $"{category.Name}.{serviceNames[randomIndex]}",
                    Description = $"Description of Service {serviceNames[randomIndex]}",
                    ServiceCharge = random.Next(20, 100),
                    Score = (float)Math.Round(faker.Random.Double(3, 5), 1),
                    CompletedCount = random.Next(80, 999),
                    ImageName = $"{serviceImageNames[randomIndex]}"
                };
                category.Services.Add(service);
            }


            return category;
        }
        #endregion

        #region Promotions
        public List<PromotionModel> GetPromotions()
        {
            List<PromotionModel> promotionModels = new List<PromotionModel>();
            promotionModels.Add(new PromotionModel
            {
                Title = "Cleaning",
                Description = "Best Cleaning",
                ImageName = "cleaning"
            });

            promotionModels.Add(new PromotionModel
            {
                Title = "Repairing",
                Description = "Best Repairing",
                ImageName = "repairing"
            });

            promotionModels.Add(new PromotionModel
            {
                Title = "Painting",
                Description = "Best Painting",
                ImageName = "painting"
            });

            return promotionModels;
        }
        #endregion

        #region Service
        public async Task<ServiceModel> GetServiceByID(string serviceID)
        {
            var faker = new Faker();
            ServiceModel model = new ServiceModel();
            model.ServiceId = serviceID;
            model.CategoryId = faker.Random.AlphaNumeric(10);
            model.Name = serviceNames[faker.Random.Int(0, serviceNames.Count - 1)];
            model.ImageName = serviceImageNames[faker.Random.Int(0, serviceImageNames.Count - 1)];
            model.ServiceCharge = faker.Random.Int(20, 100);
            model.CompletedCount = faker.Random.Int(50, 200);
            model.Score = (float)Math.Round(faker.Random.Double(3, 5), 1);
            return model;
        }

        #endregion

        #region Bookings

        public async Task<List<BookingModel>> GetBookingsByState(string state)
        {
            var faker = new Faker();
            int count = faker.Random.Int(3, 10);
            List<BookingModel> models = new List<BookingModel>();
            for (int i = 0; i < count; ++i)
            {
                var bookingModel = new BookingModel();
                bookingModel.BookingID = faker.Random.AlphaNumeric(10);
                bookingModel.ServiceId = faker.Random.AlphaNumeric(10);
                bookingModel.ClientID = faker.Random.AlphaNumeric(10);
                bookingModel.WorkerId = faker.Random.AlphaNumeric(10);

                bookingModel.StartDate = faker.Date.Between(DateTime.Today, DateTime.Today.AddDays(7)).ToString("yyyy-MM-dd");
                TimeSpan startTime = faker.Date.Timespan();

                bookingModel.StartTime = $"{startTime.Hours:D2}:{startTime.Minutes:D2}";
                bookingModel.WorkingHours = faker.Random.Int(1, 5);
                bookingModel.Description = faker.Lorem.Sentences(2);
                bookingModel.TotalPrice = faker.Random.Int(30, 150);
                bookingModel.State = BookingModel.ConvertBookingState(state);

                models.Add(bookingModel);
            }

            return models;

        }
        #endregion


        #region Workders
        public async Task<WorkerModel> GetWorkerByID(string workerID)
        {
            var faker = new Faker();
            WorkerModel workerModel = new WorkerModel();
            workerModel.WorkerId = workerID;
            workerModel.RoleId = (int)UserRole.Workder;
            workerModel.Name = faker.Name.FullName();
            workerModel.Email = faker.Internet.Email();
            workerModel.Phone = faker.Phone.PhoneNumber();
            workerModel.Address = faker.Address.FullAddress();
            workerModel.Score = (float)Math.Round(faker.Random.Double(3, 5), 1);
            workerModel.Ratings = faker.Random.Int(80, 999);
            workerModel.ImageName = "worker";
            workerModel.ServiceIds = new List<string>();
            workerModel.LaborCost = faker.Random.Int(20, 99);
            return workerModel;
        }

        public async Task<List<WorkerModel>> GetWorkersByServiceID(string serviceID)
        {
            List<WorkerModel> workerModels = new List<WorkerModel>();
            var faker = new Faker();
            int count = faker.Random.Int(2, 10);
            for (int i = 0; i < count; ++i)
            {
                WorkerModel workerModel = await GetWorkerByID(faker.Random.AlphaNumeric(10));
                workerModel.ServiceIds.Add(serviceID);
                workerModels.Add(workerModel);
            }
            
            return workerModels;
        }
        #endregion
    }
}

