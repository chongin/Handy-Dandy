using System;
using Firebase.Database;
using Firebase.Database.Query;
using Handy_Dandy.Models;
using Handy_Dandy.ViewModels;
using Bogus;

namespace Handy_Dandy.Services
{
	public class FireBaseService: IDatabaseService
	{
        private readonly FirebaseClient _firebase;
		private static string UserRootName = "Clients";
        public FireBaseService(string firebaseUrl)
		{
            _firebase = new FirebaseClient(firebaseUrl);
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
			var userRef = this._firebase.Child(UserRootName).Child(user.UserID);
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
        #endregion


        #region Categories
        public async Task<List<CategoryModel>> GetCategories()
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
            List<string> categoryImageNames = new List<string> { "category_cleaning", "category_repairing", "category_beauty" };
            List<string> categoryName = new List<string> { "Cleaning", "Repairing", "Beauty" };
            Random random = new Random();
            int randomNameIndex = random.Next(categoryImageNames.Count);
            CategoryModel category = new CategoryModel
            {
                CategoryID = $"C{index}_{randomNameIndex}",
                Name = $"{categoryName[randomNameIndex]}{index}",
                CategoryImage = $"{categoryImageNames[randomNameIndex]}",
                Services = new List<ServiceModel>()
            };

            List<string> serviceImageNames = new List<string> { "sercie_clean_floor", "service_clean_ac", "service_clean_wall",
                "service_laundry", "service_maintain_light", "service_repair_appliance"};

            List<string> serviceNames = new List<string> { "Clean Floor", "Clean AC", "Clean Wall",
                "Laundry", "Maintain Light", "Repair Appliance"};

            int numberOfServices = random.Next(3, 11);

            var faker = new Faker();
            for (int j = 0; j < numberOfServices; j++)
            {
                int randomIndex = random.Next(serviceNames.Count);
                ServiceModel service = new ServiceModel
                {
                    ServiceID = $"{category.CategoryID}_S{j}",
                    CategoryID = category.CategoryID,
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
        public async Task<List<PromotionModel>> GetPromotions()
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
                bookingModel.ServiceID = faker.Random.AlphaNumeric(10);
                bookingModel.ClientID = faker.Random.AlphaNumeric(10);
                bookingModel.WorkderID = faker.Random.AlphaNumeric(10);

                bookingModel.StartDate = faker.Date.Between(DateTime.Today, DateTime.Today.AddDays(7)).ToString();
                TimeSpan startTime = faker.Date.Timespan();

                bookingModel.StartTime = $"{startTime.Hours:D2}:{startTime.Minutes:D2}";
                bookingModel.WorkingHours = faker.Random.Int(1, 5);
                bookingModel.Description = faker.Lorem.Sentences(3);
                bookingModel.state = BookingModel.ConvertBookingState(state);

                models.Add(bookingModel);
            }

            return models;

        }
        #endregion


        #region Workders
        public async Task<WorkerModel> GetWorkersByID(string workerID)
        {
            var faker = new Faker();
            WorkerModel workerModel = new WorkerModel();
            workerModel.WorkerID = workerID;
            workerModel.RoleID = UserRole.Workder;
            workerModel.Name = faker.Name.FullName();
            workerModel.Email = faker.Internet.Email();
            workerModel.Phone = faker.Phone.PhoneNumber();
            workerModel.Address = faker.Address.FullAddress();
            workerModel.Score = (float)Math.Round(faker.Random.Double(3, 5), 1);
            workerModel.ratings = faker.Random.Int(80, 999);
            return workerModel;
        }
        #endregion
    }
}

