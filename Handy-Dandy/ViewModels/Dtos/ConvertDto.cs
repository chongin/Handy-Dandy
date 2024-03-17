using System;
using System.Linq;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class ConvertDto
	{
        public static List<WorkerDto> ConvertToWorkerDtoList(List<WorkerModel> models)
        {
            return models.Select(model => new WorkerDto(model)).ToList();
        }

        public static List<ServiceDto> ConvertToServiceDtoList(List<ServiceModel> models)
        {
            return models.Select(model => new ServiceDto(model)).ToList();
        }

        public static List<PromotionDto> ConvertToPromotionDtoList(List<PromotionModel> models)
        {
            return models.Select(model => new PromotionDto(model)).ToList();
        }

        public static List<CategoryDto> ConvertToCategoryDtoDtoList(List<CategoryModel> models)
        {
            var categoryImageNames = new List<string> { "category_cleaning", "category_repairing", "category_beauty" };
            Random random = new Random();
           
            foreach (var model in models)
            {
                int randomNameIndex = random.Next(categoryImageNames.Count);
                model.CategoryImage = $"{categoryImageNames[randomNameIndex]}";
            }
            return models.Select(model => new CategoryDto(model)).ToList();
        }
    }
}

