using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class CategoryDto : ObservableObject
    {
        public string CategoryID { get; }
        public string Name { get; }
        public string CategoryImage { get; }
        public List<ServiceDto> Services { get; }

        public CategoryDto(CategoryModel model)
		{
            CategoryID = model.CategoryID;
            Name = model.Name;
            CategoryImage = model.CategoryImage;
            Services = ConvertDto.ConvertToServiceDtoList(model.Services);
        }
	}
}

