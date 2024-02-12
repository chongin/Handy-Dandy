using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.Dtos
{
	public class PromotionDto : ObservableObject
    {
        public string Title { get; }
        public string ImageName { get; }
        public string Description { get; }

        public PromotionDto(PromotionModel model)
		{
			Title = model.Title;
			ImageName = model.ImageName;
			Description = model.Description;
		}
	}
}

