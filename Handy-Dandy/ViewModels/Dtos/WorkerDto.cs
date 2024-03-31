using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;
namespace Handy_Dandy.ViewModels.Dtos
{
	public class WorkerDto : ObservableObject
    {
        public string WorkerId { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Address { get; }
        public string Phone { get; }

        public float Score { get; }
        public int Ratings { get; }
        public int LaborCost { get; }
        public string ImageName { get; }

        public List<string> ServiceIds { get; }
        public int RoleId { get; }

        private Color _currentColor;
        public Color CurrentColor
        {
            get => _currentColor;
            set => SetProperty(ref _currentColor, value);
        }

        public WorkerDto(WorkerModel WorkerModel)
		{
            _currentColor = Color.FromArgb("#00000000");
            WorkerId = WorkerModel.WorkerId;
            Name = WorkerModel.Name;
            Email = WorkerModel.Email;
            Password = WorkerModel.Password;
            Address = WorkerModel.Address;
            Phone = WorkerModel.Phone;
            Score = WorkerModel.Score;
            Ratings = WorkerModel.Ratings;
            LaborCost = WorkerModel.LaborCost;
            //ImageName = WorkerModel.ImageName;
            ImageName = "worker.png"; // hard code first
            ServiceIds = new List<string>();
            ServiceIds = WorkerModel.ServiceIds;
            RoleId = WorkerModel.RoleId;
        }

        public string LaborCostStr
        {
            get
            {
                return $"{LaborCost}";
            }
        }

        public string RatingsStr
        {
            get
            {
                return $"({Ratings})";
            }
        }
    }
}

