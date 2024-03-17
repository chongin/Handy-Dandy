using System;
using Handy_Dandy.Models;
namespace Handy_Dandy.Services
{
	public interface IDatabaseService
	{
		Task InserUser(UserModel user);
		Task UpdateUser(UserModel user);
		Task<UserModel> QueryUserByEmail(string email);
        List<CategoryModel> GetCategories();
        Task<List<PromotionModel>> GetPromotions();
		Task<List<BookingModel>> GetBookingsByState(string state);
		Task<WorkerModel> GetWorkerByID(string workerID);
		Task<ServiceModel> GetServiceByID(string serviceID);
		Task<List<WorkerModel>> GetWorkersByServiceID(string serviceID);
		Task<UserModel> GetUserById(string userId);
    }

    public interface IDatabaseService1
    {
        Task InserUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task<UserModel> QueryUserByEmail(string email);
        Task<List<CategoryModel>> GetCategories();

        Task InitData(); 
        
    }
}

