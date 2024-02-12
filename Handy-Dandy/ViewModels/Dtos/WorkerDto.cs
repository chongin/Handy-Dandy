using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Handy_Dandy.Models;
namespace Handy_Dandy.ViewModels.Dtos
{
	public class WorkerDto : ObservableObject
    {
        public string WorkerID { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Address { get; }
        public string Phone { get; }

        public float Score { get; }
        public int Ratings { get; }
        public int LaborCost { get; }
        public string ImageName { get; }

        public List<string> ServiceIDs { get; }
        public UserRole RoleID { get; }

        private Color _currentColor;
        public Color CurrentColor
        {
            get => _currentColor;
            set => SetProperty(ref _currentColor, value);
        }

        public WorkerDto(WorkerModel WorkerModel)
		{
            _currentColor = Color.FromArgb("#00000000");
            WorkerID = WorkerModel.WorkerID;
            Name = WorkerModel.Name;
            Email = WorkerModel.Email;
            Password = WorkerModel.Password;
            Address = WorkerModel.Address;
            Phone = WorkerModel.Phone;
            Score = WorkerModel.Score;
            Ratings = WorkerModel.Ratings;
            LaborCost = WorkerModel.LaborCost;
            ImageName = WorkerModel.ImageName;

            ServiceIDs = new List<string>();
            ServiceIDs = WorkerModel.ServiceIDs;
            RoleID = WorkerModel.RoleID;
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

