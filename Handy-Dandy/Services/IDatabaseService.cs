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
        List<PromotionModel> GetPromotions();

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
        List<PromotionModel> GetPromotions();

        List<CategoryModel> GetCategories();
        CategoryModel GetCategoryById(string categoryId);
        List<ServiceWorkerModel> GetServiceWorkerModels();
        List<WorkerModel> GetWorkersByServiceId(string serviceId);
        List<WorkerModel> GetWorkerModels();

        Task InitData();
        Task InserBooking(string userName, BookingModel model);
    }
}

